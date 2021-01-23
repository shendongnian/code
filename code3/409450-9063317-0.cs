                var worker = new BackgroundWorker();
                worker.DoWork += (sender, e) =>
                    {
                        var timer = new Timer();
                        while (timer.Enabled)
                        {
                            // call the database...
                            // at some point: timer.Stop();
                            
                        } 
                        // if we are here, timer is no longer Enabled
                        // RunWorkerCompleted event will be fired next
                    };
