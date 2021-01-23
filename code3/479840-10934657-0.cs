      using (var ms = new MemoryStream())
                {
                    var sw = new StreamWriter(ms);
                    
                        sw.WriteLine("data");
                        sw.WriteLine("data 2");
                        ms.Position = 0;
                        using (var sr = new StreamReader(ms))
                        {
                            Console.WriteLine(sr.ReadToEnd());
                        }
               }    
  
