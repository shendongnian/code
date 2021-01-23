    namespace Inheritance
    {
        using System;
    
        public class Program
        {
            internal protected class BaseClass
            {
                public BaseClass() { }
    
                protected string methodName;
                protected int noOfTimes;
                public virtual void Execute(string MethodName, int NoOfTimes)
                {
                    this.methodName = MethodName;
                    this.noOfTimes = NoOfTimes;
                }
            }
    
            internal class DerivedClass : BaseClass
            {
                public DerivedClass() : base() { }
    
                public override void Execute(string MethodName, int NoOfTimes)
                {
                    base.Execute(MethodName, NoOfTimes);
                    Console.WriteLine("Running {0}, {1} times", base.methodName, base.noOfTimes);
                }
            }
    
            static void Main(string[] args)
            {
                DerivedClass d = new DerivedClass();
                d.Execute("Func", 2);
    
                Console.ReadLine();
            }
        }
    }
