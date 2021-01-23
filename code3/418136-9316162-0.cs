    using (StreamWriter sw = new StreamWriter(Path.GetTempFileName()))
    {
        using (StreamReader sr = new StreamReader(@"YourFile"))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    sw.Write(line + ",");
                }
            }
        }
    }
