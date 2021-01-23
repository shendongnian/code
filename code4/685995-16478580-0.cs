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
    static class Program
    {
        static void Main()
        {
            string[] names = { "Id", "Name", "Size", "When" };
            Type[] types = { typeof(int), typeof(string), typeof(float), typeof(DateTime?) };
    
            var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName("DynamicStuff"),
                AssemblyBuilderAccess.Run);
            var module = asm.DefineDynamicModule("DynamicStuff");
            var tb = module.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Serializable);
            tb.SetCustomAttribute(new CustomAttributeBuilder(
                typeof(DataContractAttribute).GetConstructor(Type.EmptyTypes), new object[0]));
            
            FieldBuilder[] fields = new FieldBuilder[names.Length];
    
            var dataMemberCtor = typeof(DataMemberAttribute).GetConstructor(Type.EmptyTypes);
            var dataMemberProps = new[] {typeof(DataMemberAttribute).GetProperty("Order")};
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
                    dataMemberProps, new object[1] {i+1}));
            
            }
            var type = tb.CreateType();
            var obj = Activator.CreateInstance(type);
            dynamic dyn = obj; // just a lazy way to set members for now
                 // could also add an indexer, or use fast-member
            dyn.Id = 123;
            dyn.When = DateTime.Now;
            dyn.Name = "abc";
            dyn.Size = 12F;
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
