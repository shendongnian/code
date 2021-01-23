    public T Create<T>(bool createSubObjects)
        {
            T MyICustomer = default(T);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"
                using System;
                using System.Collections.Generic;
                using System.Linq;
                namespace MyNameSpace
                {
                    public class RuntimeCustomer:NotifyPropertyChanged,").Append(typeof(T).FullName).Append(@"
                    {
                        string name;").Append(createSubObjects ? @"
                        IAddress address = new RuntimeAddress(); " :@"
                        IAddress address = null;").Append(@"
                        public string Name 
                        {
                            get { return name; }
                            set { SetProperty(ref name, value); }
                        }
                        public IAddress Address
                        { 
                            get { return address; }
                            set { SetProperty(ref address, value) }
                        }
                    }
                    
                    class RuntimeAddress : NotifyPropertyChanged, IAddress
                    {
                        string street;
                        public string Street 
                        {
                                get { return street; }
                                set { SetProperty(ref,street, value) }
                        }
                    }
                 }");
            Dictionary<string, string> providerOptions = new Dictionary<string, string>();
            providerOptions["CompilerVersion"] = "v3.5"; //OR YOUR VERSION
            Microsoft.CSharp.CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider(providerOptions);
            System.CodeDom.Compiler.CompilerParameters parameters = new System.CodeDom.Compiler.CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.IncludeDebugInformation = true;
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add(typeof(System.Linq.Enumerable).Assembly.Location);
            parameters.ReferencedAssemblies.Add(System.Reflection.Assembly.GetCallingAssembly().Location);
            parameters.ReferencedAssemblies.Add(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.CodeDom.Compiler.CompilerResults results = provider.CompileAssemblyFromSource(parameters, sb.ToString());
            if (results.Errors.Count == 0)
            {
                Type generated = results.CompiledAssembly.GetType("MyNameSpace.RuntimeAddress");
                MyICustomer = (T)generated.GetConstructor(Type.EmptyTypes).Invoke(null);
            }
            else
            {
              //Do something
            }
            return MyICustomer; 
        }
