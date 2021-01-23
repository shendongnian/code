        private void DoBackgroundWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            do
            { 
                    if (_lastKeyPress != _originDateTime)
                    {
                        Thread.Sleep(DelayInMilliseconds);
                        DateTime now = DateTime.Now;
                        TimeSpan delta = now - _lastKeyPress;
                        if (delta < new TimeSpan(0, 0, 0, 0, DelayInMilliseconds))
                        {
                            continue;
                        }
                    }
                    //do stuff
            } while (true);
        }
