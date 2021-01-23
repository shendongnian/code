    public void ProcessRequest(HttpContext context)
    {
        string tele = HttpContext.Current.Request.QueryString["tele"];
        string ramal = HttpContext.Current.Request.QueryString["ramal"];
        string dac = HttpContext.Current.Request.QueryString["dac"];
        string cti = HttpContext.Current.Request.QueryString["cti"];
        if ((tele != null) && (ramal != null) && (dac != null) && (cti != null))
        {
            string strLine = string.Empty;
            string strNewLine = string.Empty;
            int intCountBuffer = 0;
            MemoryStream pcmStream = null;
            MemoryStream audioStream = null;
            bool blnArmazenarBuffer = true;
            try
            {
                TcpClient oClient = new TcpClient();
                oClient.Connect(tele, 22000);
                ns = oClient.GetStream();
                write(ns, "ondelogar");
                ns = oClient.GetStream();
                write(ns, "monitorarRamalViaRede(" + tele + ";" + ramal + ";" + dac + ";" + cti + ")");
                Thread.Sleep(1000);
                context.Response.ClearContent();
                context.Response.ClearHeaders();
                context.Response.BufferOutput = false;
                context.Response.AddHeader("Content-Disposition", "attachment; filename=Gravacao");
                context.Response.ContentType = "audio/x-wav";
                int readCount;
                byte[] data = new byte[oClient.ReceiveBufferSize];
                while ((readCount = ns.Read(data, 0, oClient.ReceiveBufferSize)) != 0)
                {
                    using (StringReader readerTest = new StringReader(read(ns)))
                    {
                        strLine = readerTest.ReadLine();
                        if (strLine.Substring(0, 13) == "BufferDeAudio")
                        {
                            strLine = strLine.Replace("BufferDeAudio(", string.Empty);
                            strLine = strLine.Replace(")", string.Empty);
                            strLine = strLine.Replace(" ", string.Empty);
                            strLine = strLine.Trim();
                            if (blnArmazenarBuffer == true)
                            {
                                strNewLine += strLine;
                                intCountBuffer++;
                                // Holds 10 packages (or 10 seconds) in buffer
                                // Note: Only for ensuring that the first transmission is delivered.
                                if (intCountBuffer >= 10)
                                {
                                    pcmStream = VoxToWav(strNewLine);
                                    strNewLine = string.Empty;
                                    // ChunkSize
                                    // Note. See the documentation on: https://ccrma.stanford.edu/courses/422/projects/WaveFormat/
                                    pcmStream.Position = 4;
                                    pcmStream.WriteByte(12);
                                    pcmStream.Position = 5;
                                    pcmStream.WriteByte(77);
                                    pcmStream.Position = 6;
                                    pcmStream.WriteByte(104);
                                    pcmStream.Position = 7;
                                    pcmStream.WriteByte(28);
                                    // SubChunk2Size
                                    pcmStream.Position = 40;
                                    pcmStream.WriteByte(232);
                                    pcmStream.Position = 41;
                                    pcmStream.WriteByte(76);
                                    pcmStream.Position = 42;
                                    pcmStream.WriteByte(104);
                                    pcmStream.Position = 43;
                                    pcmStream.WriteByte(28);
                                    if (context.Response.IsClientConnected)
                                    {
                                        // The first time you step through the loop, i send wav header
                                        audioStream = new MemoryStream();
                                        audioStream.Position = 0;
                                        pcmStream.Position = 0;
                                        audioStream.Write(pcmStream.ToArray(), 0, (Int32)pcmStream.Length);
                                    }
                                    blnArmazenarBuffer = false;
                                }
                            }
                            else
                            {
                                pcmStream = VoxToWav(strLine);
                                strLine = string.Empty;
                                if (context.Response.IsClientConnected)
                                {
                                    // Here I have already sent the header. So no need to send it over again.
                                    audioStream = new MemoryStream();
                                    byte[] arr1 = pcmStream.ToArray();
                                    int x = 44;
                                    while (x < (arr1.Length))
                                    {
                                        audioStream.Position = x - 44;
                                        audioStream.WriteByte(arr1[x]);
                                        x++;
                                    }
                                }
                            }
                            context.Response.OutputStream.Write(audioStream.ToArray(), 0, (Int32)audioStream.Length);
                            context.Response.OutputStream.Flush();
                            context.Response.OutputStream.Close();
                            audioStream.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(path))
                {
                    StreamWriter w = File.AppendText(path);
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    w.WriteLine("  :");
                    w.WriteLine("  :{0}", "Play.ashx");
                    w.WriteLine("  :{0}", ex.Message);
                    w.WriteLine("-------------------------------");
                    w.Flush();
                    w.Close();
                }
            }
            ns.Close();
        }
    }
    private void write(NetworkStream ns, string message)
    {
        byte[] msg = Encoding.ASCII.GetBytes(message + Environment.NewLine);
        ns.Write(msg, 0, msg.Length);
    }
    private string read(NetworkStream ns)
    {
        StringBuilder sb = new StringBuilder();
        if (ns.CanRead)
        {
            byte[] readBuffer = new byte[1024];
            int numBytesRead = 0;
            do
            {
                numBytesRead = ns.Read(readBuffer, 0, readBuffer.Length);
                sb.AppendFormat("{0}", Encoding.ASCII.GetString(readBuffer, 0, numBytesRead));
                sb.Replace(Convert.ToChar(24), ' ');
                sb.Replace(Convert.ToChar(255), ' ');
                sb.Replace('?', ' ');
            }
            while (ns.DataAvailable);
        }
        return sb.ToString();
    }
    private MemoryStream VoxToWav(string strLine)
    {
        //How do I get the data in hexadecimal. This trick is to order them in pairs.
        byte[] byteOut = new byte[strLine.Length / 2];
        int j = 0;
        while (j < (strLine.Length))
        {
            byteOut[j / 2] = Convert.ToByte(strLine.Substring(j, 2), 16);
            j = j + 2;
        }
        Stream s = new MemoryStream(byteOut);
        BinaryReader br = new BinaryReader(s);
        MemoryStream pcmStream = new MemoryStream();
        IntPtr pcmFormat = AudioCompressionManager.GetPcmFormat(1, 16, 6000);
        WaveWriter ww = new WaveWriter(pcmStream, AudioCompressionManager.FormatBytes(pcmFormat));
        Vox.Vox2Wav(br, ww);
        return pcmStream;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
