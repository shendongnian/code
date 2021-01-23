    using System;
    using System.Reflection;
    
    namespace ProgrammingSystem
    {
        public class Program
        {
            private System.Reflection.Assembly assembly;
    
            public Program(System.Reflection.Assembly assembly)
            {
                this.assembly = assembly;
            }
    
            public event EventHandler<OutputEventArgs> ProgramOutput;
    
            public void Run()
            {
                Type programType = this.assembly.GetType("C");
                object program = Activator.CreateInstance(programType);
                EventInfo outputEvent = programType.GetEvent("output");
                Delegate delegateInstance = Delegate.CreateDelegate(
                                                        outputEvent.EventHandlerType, this,
                                                        typeof(Program).GetMethod("OutputHandler", BindingFlags.NonPublic | BindingFlags.Instance));
                MethodInfo addHandlerMethod = outputEvent.GetAddMethod();
                addHandlerMethod.Invoke(program, new [] { delegateInstance });
    
                programType.GetMethod("Run").Invoke(program, null);
            }
    
            private void OutputHandler(string s)
            {
                this.Fire(ProgramOutput, s);
            }
        }
    }
    
    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.CSharp;
    
    namespace ProgrammingSystem
    {
        public class Compiler
        {
            public Program Compile(Code code)
            {
                string template = @"
    using System;
    public class C 
    {
        public event Output output;
        public void Run() 
        { 
            [[Source]]
            output(""end"");
        }
    }
    public delegate void Output(string s);
    ";
    
                string source = template.Replace("[[Source]]", code.Source);
    
                CodeDomProvider compiler = new CSharpCodeProvider();
    
                CompilerParameters parameters = new CompilerParameters();
                parameters.WarningLevel = 4;
                parameters.GenerateExecutable = false;
                parameters.GenerateInMemory = true;
    
                CompilerResults r = compiler.CompileAssemblyFromSource(parameters, source);
                foreach (var item in r.Output)
                    this.Fire(Output, item);            
    
                Assembly assembly = r.CompiledAssembly;
    
                return new Program(assembly);
            }
    
            public event EventHandler<OutputEventArgs> Output;
        }
    }
