            var timer = new System.Timers.Timer(1000);
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(delegate(object sender, ElapsedEventArgs eventArgs)
                                                             {
                                                                 Console.WriteLine("Elapsed");
                                                             });
