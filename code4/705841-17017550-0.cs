    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace thisSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                BaseClass b = getClass("Child");
    
                b.SayHelloAndMyType();
            }
    
            static BaseClass getClass(string name)
            {
                BaseClass returnValue = null;
                switch (name)
                {
                    case "Base":
                        returnValue = new BaseClass();
                        break;
                    case "Child":
                        returnValue = new ChildClass();
                        break;
                    default:
                        returnValue = new BaseClass();
                        break;
                }
                return returnValue;
            }
        }
    
    
        class BaseClass
        {
            private const string NAME = "Base class";
    
            public virtual string GetName()
            {
                return NAME;
            }
    
            public virtual void SayHelloAndMyType()
            {
                Console.WriteLine("Hello from " + this.GetName() + " and my type is " + this.GetType().ToString()); //this.GetName() could be "Base class" or not. Depending on what instance it really is "this" (Base or Child)
            }
        }
    
        class ChildClass : BaseClass
        {
            private const string NAME = "Child class";
    
            public override string GetName()
            {
                return NAME;
            }
        }
    }
