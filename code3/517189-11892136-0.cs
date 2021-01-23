    public void testFileFilter()
        {
            string path = @"c:\temp\";
            int pathLen = path.Length;
            string[] badNames = { "1692.pdf", "readme.htm" };
            List<string> goodNames = new List<string>();
            string fn;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            foreach(String fp in System.IO.Directory.EnumerateFiles(path))
            {
                //System.Diagnostics.Debug.WriteLine(fp);
                fn = fp.Substring(pathLen);
                //System.Diagnostics.Debug.WriteLine(fn);
                if(badNames.Contains(fn))
                {
                    //fn = fp.Substring(pathLen);
                }
                else
                {
                    goodNames.Add(fn);
                }
            }
            sw.Stop();
            System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
            System.Diagnostics.Debug.WriteLine(goodNames.Count());
        }    
