        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;
    using System.Threading;
    internal class Program
    {
        private static int lockPoint = 0;
        private static void Main(string[] args)
        {
            const string testFile = @"H:\test\test.txt";
            FileInfo testFileInfo = new FileInfo(testFile);
            if (!testFileInfo.Directory.Exists)
            {
                testFileInfo.Directory.Create();
            }
            //  Clear our example
            if (testFileInfo.Exists)
            {
                testFileInfo.Delete();
            }
            //  Create the test file
            using (FileStream fs = File.Create(testFile))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("test file content");
            }
            Task iLockTheFileFirst = new Task(() => {
                using (FileStream fsThread = File.Open(testFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    Console.WriteLine("iLockTheFileFirst: I opened the file");
                    //  Set lockPoint to 1 and let main try and open the file
                    Interlocked.Exchange(ref lockPoint, 1);
                    //  Wait until the main thread sets lockPoint to 3
                    const int ifEqualTo3 = 3;
                    const int replaceWith4 = 4;
                    while (Interlocked.CompareExchange(ref lockPoint, replaceWith4, ifEqualTo3) != ifEqualTo3)
                    {
                        Console.WriteLine("iLockTheFileFirst: Waiting for main thread to let me finish");
                        Thread.Sleep(1000);
                    }
                }
                Console.WriteLine("iLockTheFileFirst: I have closed the file");
            });
            //  Start the thread and lock the file
            iLockTheFileFirst.Start();
            //  Now spin until the lockPoint becomes 1
            const int ifEqualTo1 = 1;
            const int replaceWith2 = 2;
            //  If lockPoint is equal to 1 (i.e. the main thread wants us to finish), then move it to 2
            while (Interlocked.CompareExchange(ref lockPoint, replaceWith2, ifEqualTo1) != ifEqualTo1)
            {
                Console.WriteLine("Main thread: waiting for iLockTheFileFirst to open the file");
                Thread.Sleep(1000);
            }
            try
            {
                Console.WriteLine("Main thread: now I'll try opening the file");
                using (FileStream fsMain = File.Open(testFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    Console.WriteLine("Main thread: I opened the file, which shouldn't be possible");
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Main thread: IOException: " + ioex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main thread: some other exception: " + ex.Message);
            }
            //  Set lockPoint to 3 and let other thread finish
            Interlocked.Exchange(ref lockPoint, 3);
            //  Wait for other thread to finish
            const int ifEqualTo4 = 4;
            const int replaceWith5 = 5;
            while (Interlocked.CompareExchange(ref lockPoint, replaceWith5, ifEqualTo4) != ifEqualTo4)
            {
                Thread.Sleep(10);
            }
            Console.WriteLine("Main thread: Press enter to finish");
            Console.ReadLine();
        }
    }
