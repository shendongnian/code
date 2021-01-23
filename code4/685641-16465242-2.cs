           private void writeItemsToFile(ListBox lb)
            {
            string path = @"c:\test\";
            string filename = "seed";
            int itemCounter = 0;
            int fileCounter = 1;
            StreamWriter sw = new StreamWriter(File.OpenWrite(System.IO.Path.Combine(path,string.Format(filename+"{0}.txt",fileCounter))));
            foreach (var s in lb.Items)
                {
                if (itemCounter > 100)
                    {
                    fileCounter++;
                    itemCounter = 0;
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                    sw = new StreamWriter(File.OpenWrite(System.IO.Path.Combine(path,string.Format(filename+"{0}.txt",fileCounter))));
                    }
                sw.WriteLine(s.ToString());
                itemCounter++;
                }
            if (sw != null)
                {
                sw.Flush();
                sw.Dispose();
                }
            }
