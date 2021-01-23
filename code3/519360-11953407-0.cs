    using System.Linq;
    using System.IO;
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives()
             .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
             foreach(DriveInfo di in drives)
             {
                 Console.WriteLine("Removable drives being used:", di.Name);
             {
        
        } 
    }
