    public class DynamicIfStatementEvaluator
    {
        public bool EvaluateBools()
        {
            // Create a new instance of the C# compiler
            //from http://mattephraim.com/blog/2009/01/02/treating-c-like-a-scripting-language/
            CSharpCodeProvider compiler = new CSharpCodeProvider();
            // Create some parameters for the compiler
            CompilerParameters parms = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            parms.ReferencedAssemblies.Add("System.dll");
            
            // Try to compile the string into an assembly
            CompilerResults results = compiler.CompileAssemblyFromSource(parms, new string[]
                                    {@"using System;
                                        class BoolEvaluator
                                        {
                                            public bool EvalBoolean()
                                            {
                                                return " + InsertBooleanStringHere! + @";
                                            }               
                                        }"});
            if (results.Errors.Count == 0)
            {
                object myClass = results.CompiledAssembly.CreateInstance("BoolEvaluator");
                if (myClass != null)
                {
                    object boolReturn = myClass.GetType().
                                             GetMethod("EvalBoolean").
                                             Invoke(myClass, null);
                    return Convert.ToBoolean(boolReturn);
                }
            }
            else
            {
                foreach (object error in results.Errors)
                {
                    MessageBox.Show(error.ToString());
                }
            }
            return false;
        }        
    }
