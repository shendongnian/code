        Test Object;
        public Form1()
        {
            //some initializing code
            Object = new Test();
            //the rest of initializing code
        }
        void Timer1_Tick(object sender,EventArgs e)
        {
            Object.StartTest(rand, callbackFunction)
            timer1.Stop();   
        }
