            int i=1;
            string path = @"E:\Project\C_Sharp\Tutorial\Console_App\FileSystem\Output\";
            if (Directory.Exists(path))
            {
                for (i = 1; i < 100; i++)
                {
                    string FileName = "MyTest" + i + ".txt";
                    var newpath= path + FileName;
                    // Create a file to write to. 
                    if(File.Exists(newpath)){
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Hello");
                        sw.WriteLine("And");
                        sw.WriteLine("Welcome");
                    }}
    
                }
            }
