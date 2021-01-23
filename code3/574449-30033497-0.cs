            private void Loopy(int times)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Loopy(times);
                    });
                }
                else
                {
                    count = times;
                    timer = new Timer();
                    timer.Interval = 1000;
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Start();
                }
            }
