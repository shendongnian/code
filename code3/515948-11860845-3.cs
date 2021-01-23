     var A = new Task<string>(DoA);
     var B = new Task<string>(DoB);
     A.Start();
     B.Start();
     Task.WaitAll(A, B);
     var C = new Task(() =>
                             {
                                 string resultA = A.Result;
                                 string resultB = B.Result;
                                 //Do something more;
                             }
                        );
     C.Start();
