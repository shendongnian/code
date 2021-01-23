    using Newtonsoft.Json;
    using ProtoBuf;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml.Serialization;
    
    public interface IBasicRecord
    {
        object this[int field] { get; set; }
    }
    class Program
    {
        static void Main()
        {
            object o = 1;
            int foo = (int)o;
            string[] names = { "Id", "Name", "Size", "When" };
            Type[] types = { typeof(int), typeof(string), typeof(float), typeof(DateTime?) };
    
            var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName("DynamicStuff"),
                AssemblyBuilderAccess.Run);
            var module = asm.DefineDynamicModule("DynamicStuff");
            var tb = module.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Serializable);
            tb.SetCustomAttribute(new CustomAttributeBuilder(
                typeof(DataContractAttribute).GetConstructor(Type.EmptyTypes), new object[0]));
            tb.AddInterfaceImplementation(typeof(IBasicRecord));
    
            FieldBuilder[] fields = new FieldBuilder[names.Length];
            var dataMemberCtor = typeof(DataMemberAttribute).GetConstructor(Type.EmptyTypes);
            var dataMemberProps = new[] { typeof(DataMemberAttribute).GetProperty("Order") };
            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i] = tb.DefineField("_" + names[i],
                    types[i], FieldAttributes.Private);
    
                var prop = tb.DefineProperty(names[i], PropertyAttributes.None,
                    types[i], Type.EmptyTypes);
                var getter = tb.DefineMethod("get_" + names[i],
                    MethodAttributes.Public | MethodAttributes.HideBySig, types[i], Type.EmptyTypes);
                prop.SetGetMethod(getter);
                var il = getter.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0); // this
                il.Emit(OpCodes.Ldfld, field); // .Foo
                il.Emit(OpCodes.Ret); // return
                var setter = tb.DefineMethod("set_" + names[i],
                    MethodAttributes.Public | MethodAttributes.HideBySig, typeof(void), new Type[] { types[i] });
                prop.SetSetMethod(setter);
                il = setter.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0); // this
                il.Emit(OpCodes.Ldarg_1); // value
                il.Emit(OpCodes.Stfld, field); // .Foo =
                il.Emit(OpCodes.Ret);
    
                prop.SetCustomAttribute(new CustomAttributeBuilder(
                    dataMemberCtor, new object[0],
                    dataMemberProps, new object[1] { i + 1 }));
            }
    
            foreach (var prop in typeof(IBasicRecord).GetProperties())
            {
                var accessor = prop.GetGetMethod();
                if (accessor != null)
                {
                    var args = accessor.GetParameters();
                    var argTypes = Array.ConvertAll(args, a => a.ParameterType);
                    var method = tb.DefineMethod(accessor.Name,
                        accessor.Attributes & ~MethodAttributes.Abstract,
                        accessor.CallingConvention, accessor.ReturnType, argTypes);
                    tb.DefineMethodOverride(method, accessor);
                    var il = method.GetILGenerator();
                    if (args.Length == 1 && argTypes[0] == typeof(int))
                    {
                        var branches = new Label[fields.Length];
                        for (int i = 0; i < fields.Length; i++)
                        {
                            branches[i] = il.DefineLabel();
                        }
                        il.Emit(OpCodes.Ldarg_1); // key
                        il.Emit(OpCodes.Switch, branches); // switch
                        // default:
                        il.ThrowException(typeof(ArgumentOutOfRangeException));
                        for (int i = 0; i < fields.Length; i++)
                        {
                            il.MarkLabel(branches[i]);
                            il.Emit(OpCodes.Ldarg_0); // this
                            il.Emit(OpCodes.Ldfld, fields[i]); // .Foo
                            if (types[i].IsValueType)
                            {
                                il.Emit(OpCodes.Box, types[i]); // (object)
                            }
                            il.Emit(OpCodes.Ret); // return
                        }
                    }
                    else
                    {
                        il.ThrowException(typeof(NotImplementedException));
                    }
                }
                accessor = prop.GetSetMethod();
                if (accessor != null)
                {
                    var args = accessor.GetParameters();
                    var argTypes = Array.ConvertAll(args, a => a.ParameterType);
                    var method = tb.DefineMethod(accessor.Name,
                        accessor.Attributes & ~MethodAttributes.Abstract,
                        accessor.CallingConvention, accessor.ReturnType, argTypes);
                    tb.DefineMethodOverride(method, accessor);
                    var il = method.GetILGenerator();
                    if (args.Length == 2 && argTypes[0] == typeof(int) && argTypes[1] == typeof(object))
                    {
                        var branches = new Label[fields.Length];
                        for (int i = 0; i < fields.Length; i++)
                        {
                            branches[i] = il.DefineLabel();
                        }
                        il.Emit(OpCodes.Ldarg_1); // key
                        il.Emit(OpCodes.Switch, branches); // switch
                        // default:
                        il.ThrowException(typeof(ArgumentOutOfRangeException));
                        for (int i = 0; i < fields.Length; i++)
                        {
                            il.MarkLabel(branches[i]);
                            il.Emit(OpCodes.Ldarg_0); // this
                            il.Emit(OpCodes.Ldarg_2); // value
                            il.Emit(types[i].IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, types[i]); // (SomeType)
                            il.Emit(OpCodes.Stfld, fields[i]); // .Foo =
                            il.Emit(OpCodes.Ret); // return
                        }
                    }
                    else
                    {
                        il.ThrowException(typeof(NotImplementedException));
                    }
                }
            }
    
            var type = tb.CreateType();
            var obj = Activator.CreateInstance(type);
            // we'll use the index (via a known interface) to set the values
            IBasicRecord rec = (IBasicRecord)obj;
            rec[0] = 123;
            rec[1] = "abc";
            rec[2] = 12F;
            rec[3] = DateTime.Now;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0} = {1}", i, rec[i]);
            }
            using (var ms = new MemoryStream())
            {
                var ser = new XmlSerializer(type);
                ser.Serialize(ms, obj);
                Console.WriteLine("XmlSerializer: {0} bytes", ms.Length);
            }
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms, Encoding.UTF8, 1024, true))
                {
                    var ser = new JsonSerializer();
                    ser.Serialize(writer, obj);
                }
                Console.WriteLine("Json.NET: {0} bytes", ms.Length);
            }
            using (var ms = new MemoryStream())
            {
                var ser = new DataContractSerializer(type);
                ser.WriteObject(ms, obj);
                Console.WriteLine("DataContractSerializer: {0} bytes", ms.Length);
            }
            using (var ms = new MemoryStream())
            {
                Serializer.NonGeneric.Serialize(ms, obj);
                Console.WriteLine("protobuf-net: {0} bytes", ms.Length);
            }
            using (var ms = new MemoryStream())
            {
                // note: NEVER do this unless you have a custom Binder; your
                // assembly WILL NOT deserialize in the next AppDomain (i.e.
                // the next time you load your app, you won't be able to load)
                // - shown only for illustration
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                Console.WriteLine("BinaryFormatter: {0} bytes", ms.Length);
            }
        }
    }
