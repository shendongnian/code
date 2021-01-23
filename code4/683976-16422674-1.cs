    using System;
    using System.Runtime.Remoting;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var list = new[] {1, 1, 3, 2, 2, 4};
                TypeBase typeClass = null;
                foreach (var i in list)
                {
                    ObjectHandle handle = Activator.CreateInstanceFrom("ConsoleApplication1", string.Format("{0}{1}", "Type", i));//Program- Name of the assembl
                    var typeBase = (TypeBase) handle.Unwrap();
                    typeBase.Type = i;
                    typeClass.LoadDetails();
                }
            }
        }
    
        public class TypeBase
        {
            public int Type { get; set; }
    
            public virtual void LoadDetails()
            {
                throw new NotImplementedException();
            }
        }
    
        public class Type1 : TypeBase
        {
            public override void LoadDetails()
            {
                // Load type Specific details
            }
        }
    }
