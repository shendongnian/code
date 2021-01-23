            DirectoryInfo DirInfo = new DirectoryInfo(@"C:\DataLoad\");
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Start();
                Int64 ttl = 0;
                Int32 fileCount = 0;
                foreach (FileInfo fi in DirInfo.EnumerateFiles("*", SearchOption.AllDirectories))
                {
                    ttl += fi.Length;
                    fileCount++;
                }
                sw.Stop();
                Debug.WriteLine(sw.ElapsedMilliseconds.ToString() + " " + fileCount.ToString());
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.ToString());
            }
