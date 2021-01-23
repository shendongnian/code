           private void button6_Click(object sender, EventArgs e)
        {
  
            //create With Input FileNames
            AddFileToArchive_InputByte(new ZipItem[]{ new ZipItem( @"E:\b\1.jpg",@"images\1.jpg"),
                new ZipItem(@"E:\b\2.txt",@"text\2.txt")}, @"C:\test.zip");
            //create with input stream
            AddFileToArchive_InputByte(new ZipItem[]{ new ZipItem(File.ReadAllBytes( @"E:\b\1.jpg"),@"images\1.jpg"),
                new ZipItem(File.ReadAllBytes(@"E:\b\2.txt"),@"text\2.txt")}, @"C:\test.zip");
            //Create Archive And Return StreamZipFile
            MemoryStream GetStreamZipFile = AddFileToArchive(new ZipItem[]{ new ZipItem( @"E:\b\1.jpg",@"images\1.jpg"),
                new ZipItem(@"E:\b\2.txt",@"text\2.txt")});
            //Extract in memory
            ZipItem[] ListitemsWithBytes = ExtractItems(@"C:\test.zip");
            //Choese Files For Extract To memory
            List<string> ListFileNameForExtract = new List<string>(new string[] { @"images\1.jpg", @"text\2.txt" });
            ListitemsWithBytes = ExtractItems(@"C:\test.zip", ListFileNameForExtract);
            // Choese Files For Extract To Directory
            ExtractItems(@"C:\test.zip", ListFileNameForExtract, "c:\\extractFiles");
        }
        public struct ZipItem
        {
            string _FileNameSource;
            string _PathinArchive;
            byte[] _Bytes;
            public ZipItem(string __FileNameSource, string __PathinArchive)
            {
                _Bytes=null ;
                _FileNameSource = __FileNameSource;
                _PathinArchive = __PathinArchive;
            }
            public ZipItem(byte[] __Bytes, string __PathinArchive)
            {
                _Bytes = __Bytes;
                _FileNameSource = "";
                _PathinArchive = __PathinArchive;
            }
            public string FileNameSource
            {
                set
                {
                    FileNameSource = value;
                }
                get
                {
                    return _FileNameSource;
                }
            }
            public string PathinArchive
            {
                set
                {
                    _PathinArchive = value;
                }
                get
                {
                    return _PathinArchive;
                }
            }
            public byte[] Bytes
            {
                set
                {
                    _Bytes = value;
                }
                get
                {
                    return _Bytes;
                }
            }
        }
         public void AddFileToArchive(ZipItem[] ZipItems, string SeveToFile)
        {
            MemoryStream memoryStream = new MemoryStream();
            //Create Empty Archive
            ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true);
            foreach (ZipItem item in ZipItems)
            {
                //Create Path File in Archive
                ZipArchiveEntry FileInArchive = archive.CreateEntry(item.PathinArchive);
               
                //Open File in Archive For Write
                var OpenFileInArchive = FileInArchive.Open();
               
                //Read Stream
                FileStream fsReader = new FileStream(item.FileNameSource, FileMode.Open, FileAccess.Read);
              
                byte[] ReadAllbytes = new byte[4096];//Capcity buffer
                int ReadByte = 0;
                while (fsReader.Position != fsReader.Length)
                {
                    //Read Bytes
                    ReadByte = fsReader.Read(ReadAllbytes, 0, ReadAllbytes.Length);
                    //Write Bytes
                    OpenFileInArchive.Write(ReadAllbytes, 0, ReadByte);
                }
                fsReader.Dispose();
                OpenFileInArchive.Close();
            }
            archive.Dispose();
            using (var fileStream = new FileStream(SeveToFile, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
            }
    
        }
         public MemoryStream  AddFileToArchive(ZipItem[] ZipItems)
        {
            MemoryStream memoryStream = new MemoryStream();
            //Create Empty Archive
            ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true);
            foreach (ZipItem item in ZipItems)
            {
                //Create Path File in Archive
                ZipArchiveEntry FileInArchive = archive.CreateEntry(item.PathinArchive);
               
                //Open File in Archive For Write
                var OpenFileInArchive = FileInArchive.Open();
               
                //Read Stream
                FileStream fsReader = new FileStream(item.FileNameSource, FileMode.Open, FileAccess.Read);
              
                byte[] ReadAllbytes = new byte[4096];//Capcity buffer
                int ReadByte = 0;
                while (fsReader.Position != fsReader.Length)
                {
                    //Read Bytes
                    ReadByte = fsReader.Read(ReadAllbytes, 0, ReadAllbytes.Length);
                    //Write Bytes
                    OpenFileInArchive.Write(ReadAllbytes, 0, ReadByte);
                }
                fsReader.Dispose();
                OpenFileInArchive.Close();
            }
            archive.Dispose();
          
            return memoryStream;
    
        }
         public void AddFileToArchive_InputByte(ZipItem[] ZipItems, string SeveToFile)
        {
            MemoryStream memoryStream = new MemoryStream();
            //Create Empty Archive
            ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true);
            foreach (ZipItem item in ZipItems)
            {
                //Create Path File in Archive
                ZipArchiveEntry FileInArchive = archive.CreateEntry(item.PathinArchive);
               
                //Open File in Archive For Write
                var OpenFileInArchive = FileInArchive.Open();
               
                //Read Stream
              //  FileStream fsReader = new FileStream(item.FileNameSource, FileMode.Open, FileAccess.Read);
              
                byte[] ReadAllbytes = new byte[4096];//Capcity buffer
                int ReadByte = 4096 ;int  TotalWrite=0;
                while (TotalWrite != item.Bytes.Length)
                {
                    if(TotalWrite+4096>item.Bytes.Length)
                     ReadByte=item.Bytes.Length-TotalWrite;
                    Array.Copy(item.Bytes, TotalWrite, ReadAllbytes, 0, ReadByte);
                     
              
                    //Write Bytes
                    OpenFileInArchive.Write(ReadAllbytes, 0, ReadByte);
                    TotalWrite += ReadByte;
                }
                
                OpenFileInArchive.Close();
            }
            archive.Dispose();
            using (var fileStream = new FileStream(SeveToFile, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
            }
   
        }
         public MemoryStream  AddFileToArchive_InputByte(ZipItem[] ZipItems)
        {
            MemoryStream memoryStream = new MemoryStream();
            //Create Empty Archive
            ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true);
            foreach (ZipItem item in ZipItems)
            {
                //Create Path File in Archive
                ZipArchiveEntry FileInArchive = archive.CreateEntry(item.PathinArchive);
               
                //Open File in Archive For Write
                var OpenFileInArchive = FileInArchive.Open();
               
                //Read Stream
              //  FileStream fsReader = new FileStream(item.FileNameSource, FileMode.Open, FileAccess.Read);
              
                byte[] ReadAllbytes = new byte[4096];//Capcity buffer
                int ReadByte = 4096 ;int  TotalWrite=0;
                while (TotalWrite != item.Bytes.Length)
                {
                    if(TotalWrite+4096>item.Bytes.Length)
                     ReadByte=item.Bytes.Length-TotalWrite;
                    Array.Copy(item.Bytes, TotalWrite, ReadAllbytes, 0, ReadByte);
                     
              
                    //Write Bytes
                    OpenFileInArchive.Write(ReadAllbytes, 0, ReadByte);
                    TotalWrite += ReadByte;
                }
                
                OpenFileInArchive.Close();
            }
            archive.Dispose();
           
            return memoryStream;
        }
         public void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName)
         {
             //Opens the zip file up to be read
             using (ZipArchive archive = ZipFile.OpenRead(sourceArchiveFileName))
             {
                 if (Directory.Exists(destinationDirectoryName)==false )
                     Directory.CreateDirectory(destinationDirectoryName);
                 //Loops through each file in the zip file
                 archive.ExtractToDirectory(destinationDirectoryName);
             }
         }  
         public void   ExtractItems(string sourceArchiveFileName,List< string> _PathFilesinArchive, string destinationDirectoryName)
         {
           
             //Opens the zip file up to be read
             using (ZipArchive archive = ZipFile.OpenRead(sourceArchiveFileName))
             {
               
                 //Loops through each file in the zip file
                 foreach (ZipArchiveEntry file in archive.Entries)
                 {
                     int PosResult = _PathFilesinArchive.IndexOf(file.FullName);
                     if (PosResult != -1)
                     {
                         //Create Folder
                         if (Directory.Exists( destinationDirectoryName + "\\" +Path.GetDirectoryName( _PathFilesinArchive[PosResult])) == false)
                             Directory.CreateDirectory(destinationDirectoryName + "\\" + Path.GetDirectoryName(_PathFilesinArchive[PosResult]));
                         Stream OpenFileGetBytes = file.Open();
                         FileStream   FileStreamOutput = new FileStream(destinationDirectoryName + "\\" + _PathFilesinArchive[PosResult], FileMode.Create);
                         byte[] ReadAllbytes = new byte[4096];//Capcity buffer
                         int ReadByte = 0; int TotalRead = 0; 
                         while (TotalRead != file.Length)
                         {
                             //Read Bytes
                             ReadByte = OpenFileGetBytes.Read(ReadAllbytes, 0, ReadAllbytes.Length);
                             TotalRead += ReadByte;
                             //Write Bytes
                             FileStreamOutput.Write(ReadAllbytes, 0, ReadByte);
                         }
                         FileStreamOutput.Close();
                         OpenFileGetBytes.Close();
                         
                        
                         _PathFilesinArchive.RemoveAt(PosResult);
                     }
                     if (_PathFilesinArchive.Count == 0)
                         break;
                 }
             }
            
         }
     
         public ZipItem[] ExtractItems(string sourceArchiveFileName)
         {
           List<  ZipItem> ZipItemsReading = new List<ZipItem>();
             //Opens the zip file up to be read
             using (ZipArchive archive = ZipFile.OpenRead(sourceArchiveFileName))
             {
                
                 //Loops through each file in the zip file
                 foreach (ZipArchiveEntry file in archive.Entries)
                 {
                     Stream OpenFileGetBytes = file.Open();
                     MemoryStream memstreams = new MemoryStream();
                     byte[] ReadAllbytes = new byte[4096];//Capcity buffer
                     int ReadByte = 0; int TotalRead = 0;
                     while (TotalRead != file.Length)
                     {
                         //Read Bytes
                         ReadByte = OpenFileGetBytes.Read(ReadAllbytes, 0, ReadAllbytes.Length);
                         TotalRead += ReadByte;
                         //Write Bytes
                         memstreams.Write(ReadAllbytes, 0, ReadByte);
                     }
                     memstreams.Position = 0;
                     OpenFileGetBytes.Close();
                     memstreams.Dispose();
                     ZipItemsReading.Add(new ZipItem(memstreams.ToArray(),file.FullName));
                 }
             }
             return ZipItemsReading.ToArray();
         }
         public ZipItem[] ExtractItems(string sourceArchiveFileName,List< string> _PathFilesinArchive)
         {
           List<  ZipItem> ZipItemsReading = new List<ZipItem>();
             //Opens the zip file up to be read
             using (ZipArchive archive = ZipFile.OpenRead(sourceArchiveFileName))
             {
  
                 //Loops through each file in the zip file
                 foreach (ZipArchiveEntry file in archive.Entries)
                 {
                     int PosResult = _PathFilesinArchive.IndexOf(file.FullName); 
                     if (PosResult!= -1)
                     {
                         Stream OpenFileGetBytes = file.Open();
                         MemoryStream memstreams = new MemoryStream();
                         byte[] ReadAllbytes = new byte[4096];//Capcity buffer
                         int ReadByte = 0; int TotalRead = 0;  
                         while (TotalRead != file.Length)
                         {
                             //Read Bytes
                             ReadByte = OpenFileGetBytes.Read(ReadAllbytes, 0, ReadAllbytes.Length);
                             TotalRead += ReadByte;
                             //Write Bytes
                             memstreams.Write(ReadAllbytes, 0, ReadByte);
                         }
                         //Create item
                         ZipItemsReading.Add(new ZipItem(memstreams.ToArray(),file.FullName));
                         OpenFileGetBytes.Close();
                         memstreams.Dispose();
                         
                         _PathFilesinArchive.RemoveAt(PosResult);
                     }
                     if (_PathFilesinArchive.Count == 0)
                         break;
                 }
             }
             return ZipItemsReading.ToArray();
         }
