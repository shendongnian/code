    class Program
        {
            private static string processName = DateTime.Now.ToString("hh.mm.ss");
            private static bool exitProcess;
    
            private static Mutex firstLock
            {
                get
                {
                    return new Mutex(false, "stackoverflow.com/questions/11304052/");
                }
            }
            
            private static Mutex secondLock
            {
                get
                {
                    return new Mutex(false, "stackoverflow.com/questions/11304052/ #2");
                }
            }
            
    
            static void Main(string[] args)
            {
                Console.WriteLine(string.Format("Process {0} starting", processName));
    
                exitProcess = false;
    
                while (true)
                {
                    using (firstLock)
                    {
                        Console.WriteLine(string.Format("Process {0} trying to get #1 mutex", processName));
    
                        if (!firstLock.WaitOne(TimeSpan.FromSeconds(1), false))
                        {
                            Console.WriteLine(string.Format("Process {0} #1 mutex in use, waiting for release", processName));
    
                            bool killFirstApp = false;
    
                            while (!killFirstApp)
                            {
                                killFirstApp = LockSecondMutex();
                            }
    
                            continue;
                        }
    
                        new Thread(MonitorSecondMutex).Start();
    
                        RunProgram();
    
                        firstLock.ReleaseMutex();
    
                        break;
                    }
                }
            }
    
            static void RunProgram()
            {
                while (!exitProcess)
                {
                    Console.WriteLine(string.Format("Process {0} running", processName));
    
                    Thread.Sleep(1000);
                }
            }
    
            static void MonitorSecondMutex()
            {
                while (true)
                {
                    using (secondLock)
                    {
                        if (!secondLock.WaitOne(TimeSpan.FromSeconds(2), false))
                        {
                            Console.WriteLine(string.Format("Process {0} lost second mutex. Will now exit.", processName));
    
                            exitProcess = true;
                            
                            break;
                        }
    
                        secondLock.ReleaseMutex();
                    }
    
                    Thread.Sleep(500);
                }
            }
    
            static bool LockSecondMutex()
            {
                while (true)
                {
                    using (secondLock)
                    {
                        if (!secondLock.WaitOne(TimeSpan.FromSeconds(2), false))
                        {
                            continue;
                        }
    
                        Thread.Sleep(5000);
    
                        secondLock.ReleaseMutex();
                    }
    
                    return true;
                }
            }
        }
