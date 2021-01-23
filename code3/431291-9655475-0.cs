      public void action(string result)
        {
            int n = new Random().Next(0, 5000);
            Boolean blActivateTimer = true;
            Timer timer = new Timer();
            timer.Tick += timer_Tick;
            if (!result.Contains("string1") && !result.Contains("string2"))
            {
                n += 600000;
                action1();
            }
            else
            {
                if (result.Contains("string1"))
                {
                    n += 10000;
                }
                else
                {
                    blActivateTimer = false;
                }
            }
            if (blActivateTimer)
            {
                timer.Start();
            }
        }
        void action1()
        {
         
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Timer t = (Timer)sender;
            t.Stop();
            action(result);
        }
