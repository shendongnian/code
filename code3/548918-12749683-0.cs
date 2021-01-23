    private void ConvertAudio()
        {
            string webFile = @"D:\AudioCS\bin\Debug\_web.mp3";
            string pcmFile = @"D:\AudioCS\bin\Debug\_AudioCS.wav";
            using (WaveReader wr = new WaveReader(File.OpenRead(pcmFile)))
            {
                IntPtr pcmFormat = wr.ReadFormat();
                byte[] pcmData = wr.ReadData();
                IntPtr webFormat = AudioCompressionManager.GetCompatibleFormat(pcmFormat,
                AudioCompressionManager.MpegLayer3FormatTag);
                byte[] webData = AudioCompressionManager.Convert(pcmFormat, webFormat,
                pcmData, false);
                MemoryStream ms = new MemoryStream();
     
                using (WaveWriter ww = new WaveWriter(ms,
                AudioCompressionManager.FormatBytes(webFormat)))
                {
                    ww.WriteData(webData);
                    using (WaveReader wr2 = new WaveReader(ms))
                    {
                        using (FileStream fs = File.OpenWrite(webFile))
                        {
                            wr2.MakeMP3(fs);
                        }
                    }
                }
            }
        }
