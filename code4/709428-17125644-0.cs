            String InputCode = String.Empty;
            
            InputCode = "MessageBox.Show((1 + 2 + 3).ToString());";
            System.CodeDom.Compiler.CodeDomProvider CodeDomProvider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("CSharp");
            System.CodeDom.Compiler.CompilerParameters CompilerParameters = new System.CodeDom.Compiler.CompilerParameters();
            CompilerParameters.ReferencedAssemblies.Add("System.dll");
            CompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            CompilerParameters.CompilerOptions += "/target:winexe" + " " + "/win32icon:" + "\"" + textBox6.Text + "\"";
            CompilerParameters.GenerateInMemory = true;
            
            StringBuilder Temp = new StringBuilder();
            Temp.AppendLine(@"using System;");
            Temp.AppendLine(@"using System.Windows.Forms;");
            Temp.AppendLine(@"namespace RunTimeCompiler{");
            Temp.AppendLine(@"public class Test{");
            Temp.AppendLine(@"public static void Main(){");
            Temp.AppendLine(@"public void Ergebnis(){");
            Temp.AppendLine(InputCode);
            Temp.AppendLine(@"}}}}}");
            System.CodeDom.Compiler.CompilerResults CompilerResults = CodeDomProvider.CompileAssemblyFromSource(CompilerParameters, Temp.ToString());
            //Auf CompilerFehler prüfen
            if (CompilerResults.Errors.Count > 0)
            {
                MessageBox.Show(CompilerResults.Errors[0].ErrorText, "Fehler bei Laufzeitkompilierung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
