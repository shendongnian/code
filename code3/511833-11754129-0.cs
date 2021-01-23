    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    
   
    
        class Program
        {
            static void Main(string[] args)
            {
                var files1 = new List<string>(Directory.GetFiles(args[0],
                    "*.txt",
                    SearchOption.AllDirectories));
    
    
                List<FileData> ListFiles = new List<FileData>();
    
                for (int i = 0; i < files1.Count; i++)
                { 
    
    
                FileInfo file = new FileInfo(files1[i]);
                FileData _tmpfile = new FileData(file.Name.ToString(), file.Length, 
                    File.GetLastWriteTime(files1[1]).ToString("yyyy-MM-dd H:mm:ss"),
                    File.GetLastAccessTime(files1[1]).ToString("yyyy-MM-dd H:mm:ss"));
                ListFiles.Add(_tmpfile);
                }
    
                DataSet sessions = new DataSet();
                DataTable dt = sessions.Tables["Sessions"];
                for (int i = 0; i < ListFiles.Count; i++)
                {
                    //compares every file in folder to database
                    FileData _tmp = ListFiles[i];
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (_tmp.GSFileName == dt.Rows[i][0].ToString())
                        { 
                            //put some code here
                            break; 
                        }
    
                        if (_tmp.GSSize == long.Parse(dt.Rows[i][1].ToString()))
                        {
                            //put some code here
                            break;
                        }
                    
                    }
    
    
                }
    
                
    
            }
        }
        public class FileData
        {
            string FileName = "";
    
            public string GSFileName
            {
                get { return FileName; }
                set { FileName = value; }
            }
            long Size = 0;
    
            public long GSSize
            {
                get { return Size; }
                set { Size = value; }
            }
            string DateOfModification = "";
    
            public string GSDateOfModification
            {
                get { return DateOfModification; }
                set { DateOfModification = value; }
            }
            string DateOfLastAccess = "";
    
            public string GSDateOfLastAccess
            {
                get { return DateOfLastAccess; }
                set { DateOfLastAccess = value; }
            }
    
            public FileData(string fn, long si, string dateofmod, string dateofacc)
            {
                FileName = fn;
                Size = si;
                DateOfModification = dateofmod;
                DateOfLastAccess = dateofacc;
            
            }
    
        }
    
