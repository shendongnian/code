    public class Test
    {
        public Test()
        {
            A.Start();
            B.Start();
        }
     
        int objectX = 0;
        
        Thread A = new Thread(ThreadAWorkMethod);
        Thread B = new Thread(ThreadBWorkMethod);
        
        public void ThreadAWorkMethod()
        {
            objectX = 5;
            Debug.WriteLine("Value has been changed to: " + objectX.ToString() + "at " DateTime.Now.Milliseconds);
            return;
        }
        public void ThreadBWorkMethod()
        {
            string xInThreadB = objectX.ToString();
            Debug.WriteLine("Value in thread b: " + xInThreadB + "at " DateTime.Now.Milliseconds);
            return;
        }
    }
