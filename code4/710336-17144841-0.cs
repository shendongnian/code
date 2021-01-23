        static void Main(string[] args)
        {
            var guid = Guid.NewGuid().ToString();
            var root = AppDomain.CurrentDomain.BaseDirectory;
            var batchFilePath = root + guid + ".bat";
            var cmd = @"cd C:\Users\user\Desktop\ImageMagick-6.8.6-Q16" + Environment.NewLine
                        + "convert icon.png -resize 64x64 icon1.png";
            CreateBatchFile(cmd, batchFilePath);// Temporary Batch file
            RunBatchFile(batchFilePath);
            DeleteBatchFile(batchFilePath);
        }
        private static void RunBatchFile(string batFilePath)
        {
            var myProcess = new Process();
            myProcess.StartInfo.FileName = batFilePath;
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
            myProcess.WaitForExit();
        }
        private static void DeleteBatchFile(string file)
        {
            File.Delete(file);
        }
        private static void CreateBatchFile(string input, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(input);
            writer.Close();
            fs.Close();
        }
