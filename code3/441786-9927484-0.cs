        public static Process GenerateRuntimeProcess(string processName, int aliveDuration, bool throwOnException = true)
        {
            Process result = null;
            try
            {
                AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName() { Name = processName }, AssemblyBuilderAccess.Save);
                ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(processName, processName + ".EXE");
                TypeBuilder typeBuilder = moduleBuilder.DefineType("Program", TypeAttributes.Public);
                MethodBuilder methodBuilder = typeBuilder.DefineMethod("Main", MethodAttributes.Public | MethodAttributes.Static, null, null);
                ILGenerator il = methodBuilder.GetILGenerator();
                il.UsingNamespace("System.Threading");
                il.EmitWriteLine("Hello World");
                il.Emit(OpCodes.Ldc_I4, aliveDuration);
                il.Emit(OpCodes.Call, typeof(Thread).GetMethod("Sleep", new Type[] { typeof(int) }));
                il.Emit(OpCodes.Ret);
                typeBuilder.CreateType();
                assemblyBuilder.SetEntryPoint(methodBuilder.GetBaseDefinition(), PEFileKinds.ConsoleApplication);
                assemblyBuilder.Save(processName + ".EXE", PortableExecutableKinds.Required32Bit, ImageFileMachine.I386);
                result = Process.Start(new ProcessStartInfo(processName + ".EXE")
                {
                    WindowStyle = ProcessWindowStyle.Hidden
                });
            }
            catch
            {
                if (throwOnException)
                {
                    throw;
                }
                result = null;
            }
            return result;
        }
