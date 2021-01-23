    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Net;
    using System.Collections;
    using System.Threading;
    namespace ConsoleApplication4
    {
    
    
        static class Program
        {
            private static ManualResetEvent wh;
            private static int total;
            private static int done;
            private static void Main()
            {
    
                string[] myfiles = new string[] {"file1", "file2"};
                wh = new ManualResetEvent(false);
                total = myfiles.Length;
                foreach (string myfile in myfiles)
                {
                    ThreadPool.QueueUserWorkItem(ProcessImageFile, myfile);
                }
                wh.WaitOne(Timeout.Infinite);
    
                //wohoo all files are process now, at faster rate;
    
            }
    
            private static void ProcessImageFile(object state)
            {
                string file = state as string;
    
                // process the file here
    
                Interlocked.Increment(ref done);
    
                if (done == total)
                {
                    wh.Set();
                }
    
            }
        }
    
    }
    
