    void timer_Tick(object sender, EventArgs e)
            {            
                if (btnName.Opacity < 100)
                {
                    btnName.Opacity++;
                    timer2.Stop();
                    timer2.Interval = 5000;
                    timer2.Start();
                } else {
                    timer2.Stop();
               }
            }
