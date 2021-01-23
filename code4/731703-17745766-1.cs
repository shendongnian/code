        int a = 1;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
             if(a <= 5)
             {
                CaptureFunction();
                a++;
             }
             else
                timer1.Stop();
             //place this just in case....
        }
