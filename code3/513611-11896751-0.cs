            public List<string> LoadZipFile2(string FileName)
        {
            List<string> lines = new List<string>();
            int start = System.Environment.TickCount;
            string debugtext;
            debugtext = "Reading " + FileName + "... ";
            this.richTextBoxLOG.AppendText(debugtext);
            try
            {
                //int nstart = System.Environment.TickCount;
                ZipFile zip = ZipFile.Read(FileName);
               // this.richTextBoxLOG.AppendText(String.Format("ZipFile ({0}ms)\n", System.Environment.TickCount - nstart));
                //nstart = System.Environment.TickCount;
                MemoryStream ms = new MemoryStream();
                //this.richTextBoxLOG.AppendText(String.Format("Memorystream ({0}ms)\n", System.Environment.TickCount - nstart));
                //nstart = System.Environment.TickCount;
                zip[0].Extract(ms);
                zip.Dispose();
                //this.richTextBoxLOG.AppendText(String.Format("Extract ({0}ms)\n", System.Environment.TickCount - nstart));
                //nstart = System.Environment.TickCount;
                using (var reader = new StreamReader(ms))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (reader.Peek() >= 0)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }
                ;
                //this.richTextBoxLOG.AppendText(String.Format("Read ({0}ms)\n", System.Environment.TickCount - nstart));
            }
            catch (IOException ex)
            {
                this.richTextBoxLOG.AppendText(ex.Message + "\n");
            }
            int slut = System.Environment.TickCount;
            this.richTextBoxLOG.AppendText(String.Format("Done ({0}ms)\n", slut - start));
            return (lines);
