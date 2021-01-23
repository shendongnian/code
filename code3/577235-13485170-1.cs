			ICodeCompiler compiler = codeProvider.CreateCompiler();
			CompilerParameters parameters = new CompilerParameters();
			parameters.GenerateExecutable = false;
			parameters.GenerateInMemory = true;
			parameters.OutputAssembly = "CS-Script-Tmp-Junk";
			parameters.MainClass = "CScript.Main";
			parameters.IncludeDebugInformation = false;
			
			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) {
				parameters.ReferencedAssemblies.Add(asm.Location);
			}
			
			CompilerResults results = compiler.CompileAssemblyFromSource(parameters, sourceText);
			
			if (results.Errors.Count > 0) {
				string errors = "Compilation failed:\n";
				foreach (CompilerError err in results.Errors) {
					errors += err.ToString() + "\n";
				}
				MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}	else {
				object o = results.CompiledAssembly.CreateInstance("CScript");
				Type type = o.GetType();
				MethodInfo m = type.GetMethod("Main");
				m.Invoke(o, null);
				if (File.Exists("CS-Script-Tmp-Junk")) { File.Delete("CS-Script-Tmp-Junk"); }
			}
		}
