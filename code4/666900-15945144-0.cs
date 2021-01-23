      static void Main(string[] args)
                {
                    Process p = new Process();
                    ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
                    info.RedirectStandardInput = true;
                    info.UseShellExecute = false;
                    info.CreateNoWindow = false;
        
                    p.StartInfo = info;
                    p.Start();
        
                    using (StreamWriter sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("dir");
                            
                            sw.WriteLine("ipconfig");
                        }
                    }
                    Console.ReadLine();
                }
