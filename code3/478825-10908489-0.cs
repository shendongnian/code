     static void Main(string[] args)
                {
                    
                  
                    using (Runspace rs = RunspaceFactory.CreateRunspace())
                    {
        
                        rs.Open();
                        var pipeline = rs.CreatePipeline();
                        pipeline.Commands.AddScript("$certThumbrint = \"c:\\1.txt\"\n" +
                                                    "$cert = get-item $certThumbrint\n" +
                                                    "Get-Content $cert");
        
                        foreach (var s in pipeline.Invoke())
                        {
                            Console.WriteLine(s);
                            
                        }
                        
                    }
                    Console.ReadLine();
                }
