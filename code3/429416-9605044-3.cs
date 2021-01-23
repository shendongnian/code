     private void TestDynCompile() {
             // the code you want to dynamically compile, as a string
             string code = @"
                using System;
                
                namespace DynCode {
                   public class TestClass {
                      public string MyMsg(string name) {
                         //---- this would be code your users provide
                         return string.Format(""Hello {0}!"", name);
                         //-----
                      }
                   }
                }";
    
             // obtain a reference to a CSharp compiler
             var provider = CodeDomProvider.CreateProvider("CSharp");
             // Crate instance for compilation parameters
             var cp = new CompilerParameters();
             // Add assembly dependencies
             cp.ReferencedAssemblies.Add("System.dll");
             // hold compiled assembly in memory, don't produce an output file
             cp.GenerateInMemory = true;
             cp.GenerateExecutable = false;
             // don't produce debugging information    
             cp.IncludeDebugInformation = false;
             // Compile source code
             var rslts = provider.CompileAssemblyFromSource(cp, code);
          
             if( rslts.Errors.Count == 0 ) {
                // No errors in compilation, obtain type for DynCode.TestClass
                var type = rslts.CompiledAssembly.GetType("DynCode.TestClass");
                // Create an instance for the dynamically compiled class
                dynamic instance = Activator.CreateInstance(type);
                // Invoke dynamic code
                MessageBox.Show(instance.MyMsg("Gerardo"));  // Hello Gerardo! is diplayed  =)
             }
           }
    
