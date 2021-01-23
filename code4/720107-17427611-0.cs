        static void WriteToCSV(string str, string path)
        {
            using (Stream stream = File.Create(path))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(str);
            }
        }
