    public class SampleCass
    {
        public int MyInteger { get; set;}
        
        //Similarly other properties
        public SampleClass(SampleClass tocopyfrom)
        {
                MyInteger = tocopyfropm.MyInteger;
               //Similarly populate other properties
        }
    }
