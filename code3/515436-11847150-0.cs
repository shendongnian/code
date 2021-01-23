            #region create graph
            var server = new Server()
            {
                ServerID = 0,
                ServerName = string.Concat(Environment.MachineName),
                ServerDrives = DriveInfo.GetDrives()
                                        .Where(x => x.IsReady)
                                        .Select(di => new ServerDrive()
                                        {
                                            DriveLetter = di.Name,
                                            TotalSpace = di.TotalSize,
                                            DriveLabel = di.VolumeLabel,
                                            FreeSpace = di.TotalFreeSpace,
                                            DriveType = di.DriveFormat
                                        })
                                        .ToList()
            };
            #endregion
            #region output graph
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server ID :      {0}", server.ServerID);
            Console.WriteLine("Server Name :    {0}", server.ServerName);
            Console.WriteLine();
            server.ServerDrives.ForEach(sd =>
            {
                Console.WriteLine("Drive Letter:    {0}", sd.DriveLetter);
                Console.WriteLine("Total Size:      {0}", sd.TotalSpace);
                Console.WriteLine("Volume Label:    {0}", sd.DriveLabel);
                Console.WriteLine("Free Space:      {0}", sd.FreeSpace);
                Console.WriteLine("Drive Format:    {0}", sd.DriveType);
                Console.ReadLine();
            });
            #endregion
            #region persist graph
            DataClasses1DataContext db = new DataClasses1DataContext(@"sqlserver");
            db.Servers.InsertOnSubmit(server);
            db.SubmitChanges();
            #endregion
