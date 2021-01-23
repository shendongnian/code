        interface IControl
        {
            void Paint();
        }
        
        public class SampleClass : IControl
        {
            void IControl.Paint()
            {
                System.Console.WriteLine("IControl.Paint");
            }
        }
        
    void doit(){
        SampleClass obj = new SampleClass();
        //obj.Paint();  // Compiler error.
        
        IControl c = (IControl)obj;
        c.Paint();  // Calls IControl.Paint on SampleClass.
    }
