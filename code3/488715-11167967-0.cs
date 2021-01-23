    public class MainProgram
    {
        public static List<char[]> lst = new List<char[]>();
        public static void Main(string[] args)
        {
            try
            {
                // Register for a notification. 
                GC.RegisterForFullGCNotification(10, 10);
    
                // Start a thread using WaitForFullGCProc.
                Thread startpolling = new Thread(() =>
                {
                    while (true)
                    {
                        // Check for a notification of an approaching collection.
                        GCNotificationStatus s = GC.WaitForFullGCApproach(1000);
                        if (s == GCNotificationStatus.Succeeded)
                        {
                            //Call event
    
                            Console.WriteLine("GC is about to begin");
                            GC.Collect();
    
                        }
                        else if (s == GCNotificationStatus.Canceled)
                        {
                            // Cancelled the Registration
                        }
                        else if (s == GCNotificationStatus.Timeout)
                        {
                            // Timeout occurred.
                        }
    
                        // Check for a notification of a completed collection.
                        s = GC.WaitForFullGCComplete(1000);
                        if (s == GCNotificationStatus.Succeeded)
                        {
                            //Call event
                            Console.WriteLine("GC has ended");
                        }
                        else if (s == GCNotificationStatus.Canceled)
                        {
                            //Cancelled the registration
                        }
                        else if (s == GCNotificationStatus.Timeout)
                        {
                            // Timeout occurred
                        }
    
                        Thread.Sleep(500);
                    }
    
                        
                });
                startpolling.Start();
    
                //Allocate huge memory to apply pressure on GC
                AllocateMemory();
                    
                // Unregister the process
                GC.CancelFullGCNotification();
    
            }
            catch { }
        }
    
        private static void AllocateMemory()
        {
            while (true)
            {
                    
                char[] bbb = new char[1000]; // creates a block of 1000 characters
                lst.Add(bbb);                // Adding to list ensures that the object doesnt gets out of scope   
                int counter = GC.CollectionCount(2);
                Console.WriteLine("GC Collected {0} objects", counter);
    
            }
        }
            
    }
