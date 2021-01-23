    List<FileData> result = (from a in Regex.Split(s, @"\r\n").Cast<string>().Select(a => Regex.Split(a, @" [*]"))
                             where FileData.CheckShouldUpdate(a[0], a[1])
                             select new FileData 
                             {
                                 Checksum = a[0],
                                 Filepath = a[1]
                             }).ToList();
...
    class FileData
            {
                public string Checksum { get; set; }
                public string Filepath { get; set; }
                public bool ShouldUpdate { get; set; }
                public FileData() { }
                public static bool CheckShouldUpdate(string checksum, string filename)
                {
                    // some check logic here...
                    return true;
                }
    
            }
