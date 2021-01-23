        public Assembly Compile(string[] source, string[] references) {
			CodeDomProvider provider = new CSharpCodeProvider();
			CompilerParameters cp = new CompilerParameters(references);
			cp.GenerateExecutable = false;
			cp.GenerateInMemory = true;
			cp.TreatWarningsAsErrors = false;
			
			try {
				CompilerResults res = provider.CompileAssemblyFromSource(cp, source);
				// ...
				return res.Errors.Count == 0 ? res.CompiledAssembly : null;
			}
			catch (Exception ex) {
				// ...
				return null;
			}
		}
        public object Execute(Assembly a, string className, string methodName) {
            Type t = a.GetType(className);
			if (t == null) throw new Exception("Type not found!");
			MethodInfo method = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);			// Get method
			if (method == null) throw new Exception("Method '" + methodName + "' not found!");									// Method not found
				
            object instance =  Activator.CreateInstance(t, this);
            object ret = method.Invoke(instance, null);	
            return ret;
        }
