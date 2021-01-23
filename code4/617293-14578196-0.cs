     using (DataClient proxy = new DataClient())
                {
                    Task<Object> data1= proxy.Method1();
                    Task<Object> data2 = proxy.Method2();
                    await Task.WhenAll(new Task[] { data1, data2 });
                   //Completed
               }
