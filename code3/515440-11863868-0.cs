        public class Program
    {
        List<DriveInfo> driveList = DriveInfo.GetDrives().Where(x => x.IsReady).ToList<DriveInfo>(); //Get all the drive info
        Server server = new Server();  //Create  the server object
        ServerDrive serverDrives = new ServerDrive();
        public void Main()
        {
            FakeDriveInfo();
            RealDriveInfo();
            WriteInToDB();
        }
        public static string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);
            foreach (string order in orders)
            {
                if (bytes > max)
                {
                    return string.Format("{0:##.##} {1}", Decimal.Divide(bytes, max), order);
                }
                max /= scale;
            }
            return "0 Bytes";
        }
        public void FakeDriveInfo()
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Server ID :      {0}", server.ServerID = 0);
                Console.WriteLine("Server Name :    {0}", server.ServerName = string.Concat(System.Environment.MachineName));
                Console.WriteLine();
                for (int i = 0; i < driveList.Count; i++)
                {
                    Console.WriteLine("Drive Letter:    {0}", driveList[i].Name);
                    Console.WriteLine("Total Size:      {0}", FormatBytes(driveList[i].TotalSize));
                    Console.WriteLine("Volume Label:    {0}", driveList[i].VolumeLabel);
                    Console.WriteLine("Free Space:      {0}", FormatBytes(driveList[i].TotalFreeSpace));
                    Console.WriteLine("Drive Format:    {0}", driveList[i].DriveFormat);
                    Console.ReadLine();
                }
            }
        public void RealDriveInfo()
             {
                //Insert information of one server - You will need get information of all servers
                server.ServerID = 0; //Here is necessery put PK key. I recommend doing the SQL server will automatically generate the PK.
                server.ServerName = string.Concat(System.Environment.MachineName);
                //Inserts information in the newServers object
                for (int i = 0; i < driveList.Count; i++)
                {
                    //Put here all the information to obeject Server                
                    serverDrives.DriveLetter = driveList[i].Name;
                    serverDrives.TotalSpace = driveList[i].TotalSize;
                    serverDrives.DriveLabel = driveList[i].VolumeLabel;
                    serverDrives.FreeSpace = driveList[i].TotalFreeSpace;
                    serverDrives.DriveType = driveList[i].DriveFormat;
                    server.ServerDrives.Add(serverDrives);
                }
             }
        public void WriteInToDB()
        {
            //Add the information to an SQL Database using Linq.
            DataClasses1DataContext db = new DataClasses1DataContext(@"cspsqldev");
            //   db.Servers.InsertAllOnSubmit(server);
            db.Servers.InsertOnSubmit(server);
            db.SubmitChanges();
        }
