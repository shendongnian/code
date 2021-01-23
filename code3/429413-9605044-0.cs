     private void TestDynCompile() {
             // the code you want to dynamically compile, as a string
             string code = @"
                using System;
                using System.Windows.Forms;
                
                namespace DynCode {
                   public class TestClass {
                      public void MyMsg() {
                         //---- this would be code your users provide
                         MessageBox.Show(""Hello World!"");
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
             cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
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
                instance.MyMsg();  // Hello World! is diplayed  =)
             }
           }
    
