        public object getInstance(string assemblyName, string className, object[] constructorParameters)
        {
			System.Reflection.Assembly asm = System.Reflection.Assembly.Load(assemblyName);
			return asm.CreateInstance(className, false, System.Reflection.BindingFlags.CreateInstance, null, constructorParameters, null, null);
        }
