        static void Main(string[] args)
        {
            string filePath = @"c:\log.txt";
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var streamReader = new StreamReader(stream,Encoding.Unicode))
                {
                    long pos = 0;
                    if (File.Exists(@"c:\log.txt.lastposition"))
                    {
                        string strPos = File.ReadAllText(@"c:\log.txt.lastposition");
                        pos = Convert.ToInt64(strPos);
                    }
                    streamReader.BaseStream.Seek(pos, SeekOrigin.Begin); // rewind to last set position.
                    streamReader.DiscardBufferedData(); // clearing buffer
                    for(;;)
                    {
                        string line = streamReader.ReadLine();
                        if( line==null) break;
                        ProcessLine(line);
                    }
                    // pretty sure when everything is read position is at the end of file.
                    File.WriteAllText(@"c:\log.txt.lastposition",streamReader.BaseStream.Position.ToString());
                }
            }
        }
