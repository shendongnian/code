			CodeDomProvider provider = new CSharpCodeProvider();
			CompilerParameters cp = new CompilerParameters(references.ToArray());
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
