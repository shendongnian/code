            Process p = new Process();
            p.EnableRaisingEvents = true;
            //...config your process
            p.Exited += new EventHandler((s, e) =>
            {
                if (p.ExitCode == 0)
                {
                    /*Launch your final batch*/
                }
                else
                {
                    
                }
                
            });
            p.Start();
