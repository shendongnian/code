    private const string LOG_FNAME = @"Logfile.log";
            public static void WriteMsg(string msg)
            {
                bool deleted = false;
                bool append = true;
                if (File.Exists(LOG_FNAME))
                {
                    //DateTime delDate = DateTime.Now.AddDays(-1);
                    DateTime delDate = DateTime.Now.AddMinutes(-30);
                    DateTime fileCreatedDate = File.GetCreationTime(LOG_FNAME);
                    if (DateTime.Compare(fileCreatedDate, delDate) < 0)
                    {
                        Console.WriteLine("DELETE FILE");
                        File.Delete(LOG_FNAME);
                        
                        //record that file was deleted and a new one will be created
                        deleted = true;
                    }
                }
                using (StreamWriter sw = new StreamWriter(LOG_FNAME, append))
                {
                    
                    sw.WriteLine(msg);
                    
                }
                if (deleted)
                {
                    //a new file is created. Make sure the creation time is set
                    FileInfo fi = new FileInfo(LOG_FNAME);
                    fi.CreationTime = DateTime.Now;
                }
                Console.WriteLine(msg);
            }
