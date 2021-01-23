    using System;
    class Program
    {
    
        static void Main(string[] args)
        {
            MyClass c = new MyClass();
            Console.WriteLine("Ready..");
            Console.ReadLine();
        }
    }
    
    public class MyClass
    {
        OtherClass otherClassObj = new OtherClass();
    
        public MyClass()
        {
            Console.WriteLine("Class constructor.. adding event");
            otherClassObj.OnMyDataReceived += analyzeValues;
    
            Console.WriteLine("Raising event 1");
            otherClassObj.Raise();
    
            Console.WriteLine("Raising event 2");
            otherClassObj.Raise();
        }
    
        private void analyzeValues(object sender, EventArgs e)
        {
            Console.WriteLine("Event handler");
            Console.WriteLine("Removing event");
            otherClassObj.OnMyDataReceived -= analyzeValues;
        }
    }
    
    public class OtherClass
    {
        public event EventHandler OnMyDataReceived;
    
        public void Raise()
        {
            if (OnMyDataReceived != null)
            {
                OnMyDataReceived(this, EventArgs.Empty);
            }
        }
    }
