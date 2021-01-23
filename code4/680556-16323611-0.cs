    internal class Program
    {
        public static event EventHandler SomeStaticEvent;
        private static void Main()
        {
            while (true)
            {
                var a = new A();                
                
                //here a goes out of scope but won't be collected by GC because Program still holds reference to "a" by a static event subsription
            }
        }      
        public class A
        {                       
            public A()
            {
                //if you comment this line, there is no reference from Program to A and a will be GC-ed and memory allocated will be released
                Program.SomeStaticEvent+=ProgramOnSomeStaticEvent;
            }
            private void ProgramOnSomeStaticEvent(object sender, EventArgs eventArg){}
        }
        
    }
