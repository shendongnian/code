                var worker = new BackgroundWorker();
                worker.DoWork += (sender, e) =>
                    {
                        var timer = new Timer();
                        timer.Elapsed += (s, _e) =>
                            {
                               // call the database
                            };
                        timer.Start();
                        while (timer.Enabled)
                        {
                            // at some point: timer.Stop();
                            
                        } 
                        // if we are here, timer is no longer Enabled
                        // RunWorkerCompleted event will be fired next
                    };
