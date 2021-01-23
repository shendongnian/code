    using PostSharp.Aspects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        [Serializable]
        public class ConsoleAspect : OnMethodBoundaryAspect
        {
            public override void OnEntry(MethodExecutionArgs args)
            {
                base.OnEntry(args);
    
                Console.WriteLine("line no 1");
            }
    
            public override void OnExit(MethodExecutionArgs args)
            {
                base.OnExit(args);
    
                Console.WriteLine("line no 3");
            }
        }
    }
