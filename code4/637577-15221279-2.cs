        public IEnumerable<dynamic> CreateData(ObservableCollection<ReportFieldVm> reportFields)
        {
            // Find the length of the array.
            var size = reportFields.Count;
            // Create matrix.
            var b = new int[size, size];
            // Random for the values.
            var rand = new Random((int)DateTime.Now.Ticks);
            // Build the symmetric matrix.
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        b[i,j] = rand.Next(0, 100);
                    }
                    else
                    {
                        var a = rand.Next(0, 100);
                        b[i,j] = a;
                        b[j,i] = a;
                    }
                }
            }
            // Define the assembly to add out new type to.
            var asmName = new AssemblyName("DummyAssembly");
            var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
            var mb = ab.DefineDynamicModule("DummyModule");
            // Define our type.
            var d = mb.DefineType("DummyType", TypeAttributes.Public);
            const MethodAttributes GetSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            // Define all the fields for the new type.
            foreach (var rf in reportFields.OrderBy(rf => rf.SelectOrder))
            {
                var propertyName = rf.FieldName;
                var field = d.DefineField("m_" + propertyName, typeof(int), FieldAttributes.Private);
                var property = d.DefineProperty(propertyName, PropertyAttributes.HasDefault, typeof(int), null);
                var dGetAccessor = d.DefineMethod("get_" + propertyName, GetSetAttr, typeof(int), Type.EmptyTypes);
                
                var numberGetIl = dGetAccessor.GetILGenerator();
                numberGetIl.Emit(OpCodes.Ldarg_0);
                numberGetIl.Emit(OpCodes.Ldfld, field);
                numberGetIl.Emit(OpCodes.Ret);
                var dSetAccessor = d.DefineMethod("set_" + propertyName, GetSetAttr, null, new Type[] { typeof(int) });
                var numberSetIl = dSetAccessor.GetILGenerator();
                numberSetIl.Emit(OpCodes.Ldarg_0);
                numberSetIl.Emit(OpCodes.Ldarg_1);
                numberSetIl.Emit(OpCodes.Stfld, field);
                numberSetIl.Emit(OpCodes.Ret);
                property.SetGetMethod(dGetAccessor);
                property.SetSetMethod(dSetAccessor);
            }
            // Create the type.
            var dummyType = d.CreateType();
            var array = new List<dynamic>();
            // Convert the matrix into the array of the dynamic.
            for (var i = 0; i < size; i++)
            {
                var obj = Activator.CreateInstance(dummyType);
                int j = 0;
                foreach (var rf in reportFields.OrderBy(rf => rf.SelectOrder))
                {
                    var type = obj.GetType();
                    var prop = type.GetProperty(rf.FieldName);
                    prop.SetValue(obj, b[j, i], null);
                    j++;
                }
                array.Add(obj);
            }
            return array;
        }
