    class Program
    {
        static void Main(string[] args)
        {
            var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("foo"), AssemblyBuilderAccess.RunAndSave);
            var _Module = assembly.DefineDynamicModule("fooModule");
            var PropertyComparisonType = _Module.DefineType("HIDDEN.PropertyComparison", TypeAttributes.Public, typeof(Object));
            FieldBuilder object0Field = PropertyComparisonType.DefineField("_Object0", typeof(Object), FieldAttributes.Private);
            FieldBuilder object1Field = PropertyComparisonType.DefineField("_Object1", typeof(Object), FieldAttributes.Private);
            FieldBuilder equalField = PropertyComparisonType.DefineField("_Equal", typeof(Boolean), FieldAttributes.Private);
            FieldBuilder nameField = PropertyComparisonType.DefineField("_Name", typeof(String), FieldAttributes.Private);
            FieldBuilder childsField = PropertyComparisonType.DefineField("_Childs", typeof(IEnumerable<>).MakeGenericType(PropertyComparisonType), FieldAttributes.Private);
            var PropertyComparisonConstructor = PropertyComparisonType.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new[] { typeof(Object), typeof(Object), typeof(String) });
            ILGenerator il = PropertyComparisonConstructor.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, object0Field);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Stfld, object1Field);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_3);
            il.Emit(OpCodes.Stfld, nameField);
            LocalBuilder localList0 = il.DeclareLocal(typeof(IList));
            LocalBuilder localList1 = il.DeclareLocal(typeof(IList));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Isinst, typeof(IList));
            il.Emit(OpCodes.Stloc, localList0);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Isinst, typeof(IList));
            il.Emit(OpCodes.Stloc, localList1);
            il.Emit(OpCodes.Ret);
            var type = PropertyComparisonType.CreateType();
            
            var list1 = new List<string>();
            var list2 = new List<string>();
            var s = "prop";
            var instance = Activator.CreateInstance(type, list1, list2, s);
        }
    }
