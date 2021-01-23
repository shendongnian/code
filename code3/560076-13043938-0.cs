    public int TimerTick = 0;
            private System.Threading.Timer _timer;
            public void StartTimer()
            {
                label1.Visible = true;
                label2.Visible = true;
                _timer = new System.Threading.Timer(x =>
                                                        {
                                                            if (TimerTick == 10)
                                                            {
                                                                Invoke((Action) (() =>
                                                                                     {
                                                                                         label1.Visible = false;
                                                                                         label2.Visible = false;
                                                                                     }));
                                                                _timer.Dispose();
                                                                TimerTick = 0;
                                                            }
                                                            else
                                                            {
                                                                TimerTick++;
                                                            }
    
                                                        }, null, 0, 1000);
    
            }
