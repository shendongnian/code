    Task.Factory.StartNew(testMethod).ContinueWith(p =>
                {
                    if (p.Exception != null)
                        p.Exception.Handle(x =>
                            {
                                Console.WriteLine(x.Message);
                                return false;
                            });
                });
