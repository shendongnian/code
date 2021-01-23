            using (var fs = new FileStream("path", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fs.Seek(0, SeekOrigin.End);
                using (StreamWriter sw = new StreamWriter(fs) { AutoFlush = true })
                {
                    sw.WriteLine("my text");
                }
            }
