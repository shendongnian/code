    Task.Factory.StartNew(() => 
            {
                // returns a string result
                var tsk = new Task<string>(() => { return VeryImportantThingsToDo(); });
                try
                {
                    tsk.Start();
                    if (!tsk.Wait(5000))
                        throw new TimeoutException();
                    return tsk.Result;
                }
                catch (TimeoutException)
                {
                    // Jabba Dabba Doooooooohhhhhh
                }
                return "<unknown>";
            }).ContinueWith((o) => string result = o.Result));
