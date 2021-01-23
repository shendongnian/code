    using System;
    // Declare delegate -- defines required signature:
    delegate void SampleDelegate(string message);
    
    class TestDelegate
    {
        private void CallMeUsingDelegate(string m_param)
        {
            Console.WriteLine("Called me using parameter - " + m_param);
        }
    
        public static void Main(string[] args)
        {
            // Here is the Code that uses the delegate defined above.
            SampleDelegate sd = new SampleDelegate(CallMeUsingDelegate);
            sd.Invoke("FromMain");
        }
    }
