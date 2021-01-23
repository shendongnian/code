            this.r = response;
            tasks.Add(System.Threading.Tasks.Task.Factory.StartNew(
                    () =>
                    {
                        while (true)
                        {
                            r.Write("<span>Hello</span>");
                            r.Flush(); // this will send each write to the browser
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                               
            ));
            System.Threading.Tasks.Task.WaitAll(tasks.ToArray());//this will make sure that the response will stay open   
