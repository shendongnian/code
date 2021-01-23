        public Server ProcessDriveInfo(Action<Server> initialAction, Action<Server, DriveInfo> driveInfoAction)
        {
            var driveList = DriveInfo.GetDrives().Where(x => x.IsReady).ToList();
            var server = new Server();
            initialAction(server);
            driveList.ForEach(dl => driveInfoAction(server, dl));
            return server;
        }
        public void FakeDriveInfo()
        {
            ProcessDriveInfo(WriteServerToConsole, WriteDriveInfoToConsole);
        }
        private void WriteServerToConsole(Server server)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server ID :      {0}", server.ServerID = 0);
            Console.WriteLine("Server Name :    {0}", server.ServerName = string.Concat(System.Environment.MachineName));
            Console.WriteLine();
        }
        private void WriteDriveInfoToConsole(Server server, DriveInfo t)
        {
            Console.WriteLine("Drive Letter:    {0}", t.Name);
            Console.WriteLine("Total Size:      {0}", FormatBytes(t.TotalSize));
            Console.WriteLine("Volume Label:    {0}", t.VolumeLabel);
            Console.WriteLine("Free Space:      {0}", FormatBytes(t.TotalFreeSpace));
            Console.WriteLine("Drive Format:    {0}", t.DriveFormat);
            Console.ReadLine();
        }
        public void RealDriveInfo()
        {
            var server = ProcessDriveInfo(InitialiseServer, WriteDriveInfoToServer);
            //Add the information to an SQL Database using Linq.
            var db = new DataClasses1DataContext(@"sqlserver");
            //   db.Servers.InsertAllOnSubmit(server);
            db.Servers.InsertOnSubmit(server);
            db.SubmitChanges();
        }
        private static void InitialiseServer(Server server)
        {
            // Insert information of one server - You will need get information of all servers
            server.ServerID = 0;
            // Here is necessery put PK key. I recommend doing the SQL server will automatically generate the PK.
            server.ServerName = Environment.MachineName;
        }
        private static void WriteDriveInfoToServer(Server server, DriveInfo t)
        {
            var serverDrives = new ServerDrive
                                   {
                                       DriveLetter = t.Name,
                                       TotalSpace = t.TotalSize,
                                       DriveLabel = t.VolumeLabel,
                                       FreeSpace = t.TotalFreeSpace,
                                       DriveType = t.DriveFormat
                                   };
            server.ServerDrives.Add(serverDrives);
        }
