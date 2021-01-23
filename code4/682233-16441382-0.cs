        private void SetRecurringTimer()
        {
            /*
             * The timer1.Inteval = (int)dt.Subtract(DateTime.Now).TotalMilliseconds will be minus nud_minusMinutes 
             * and if the timer1.Interval will be greater than nud_minusMinutes.Value 
             * start in the next half hour if nud.Value ==0.5 
             * and nud.Value>=1 in the next full hour that fits the timer1.Interval. 
             */
            dt = dt.AddMinutes((double)(nud.Value * (decimal)60));
            
            DateTime adjustedDT = dt.AddMinutes((int)(-1 * nud_minusMinutes.Value));
            int interval = (int)adjustedDT.Subtract(DateTime.Now).TotalMilliseconds;
            double adjustment = TimeSpan.FromMinutes((int)nud_minusMinutes.Value).TotalMilliseconds;
            if (interval > adjustment)
            {
                if (nud.Value == (decimal)0.5)
                {
                    dt = dt.AddMinutes(30); // next 1/2 hour
                }
                else
                {
                    // next full hour
                    if (dt.Minute == 0)
                    {
                        dt = dt.AddHours(1);
                    }
                    else
                    {
                        dt = dt.AddMinutes(30);
                    }
                }
                timer1.Interval = (int)dt.Subtract(DateTime.Now).TotalMilliseconds;
                timer1.Start();
            }
            else
            {
                timer1.Interval = (int)adjustedDT.Subtract(DateTime.Now).TotalMilliseconds;
                timer1.Start();
            }
        }
