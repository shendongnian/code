    using System;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    DriveInfo[] drives = DriveInfo.GetDrives();
                    foreach (DriveInfo di in drives)
                    {
                        if (di.IsReady)
                        {
                            Console.WriteLine("Volume label: {0} ", di.VolumeLabel);
                            Console.WriteLine("Drive Type: {0} ", di.DriveType);
                            Console.WriteLine("Free space: {0} bytes ", di.TotalFreeSpace);
                            Console.WriteLine("Drive Size: {0} bytes \n", di.TotalSize);
                        }
                    }
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    // handle ex
                }
            }
        }
    }
