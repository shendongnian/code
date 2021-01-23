       private bool DownLoadFile(string pstrFileName, string pstrFilePath, long plngFileSize)
        {
            try
            {
                string strNewFileSize = CalcFileSize(plngFileSize);
                int numIterations = 0;	// this is used with a modulus of the sampleInterval to check if the chunk size should be adjusted.  it is started at 1 so that the first check will be skipped because it may involve an initial delay in connecting to the web service
                Offset = 0;
                long webConfigSetting = this.mobjService.GetMaxRequestLength();
                this.MaxRequestLength = Math.Max(1, (webConfigSetting * 1024) - (2 * 1024));	// set the max buffer size to slightly less than the request length to allow for SOAP message headers etc.  
                if (File.Exists(pstrFilePath))
                {
                    Offset = new FileInfo(pstrFilePath).Length;
                    if (Offset == plngFileSize)
                        Offset = 0;
                    //File.Delete(pstrFilePath);
                }
                if (Offset == 0 && !File.Exists(pstrFilePath))   // create a new empty file
                    File.Create(pstrFilePath).Close();
                // open a file stream for the file we will write to in the start-up folder
                lblFileName.Text = pstrFileName.Substring(0, pstrFileName.LastIndexOf(".")).Replace("&", "&&");
                using (FileStream fs = new FileStream(pstrFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    pbrSummary.Maximum = (int)plngFileSize;
                    fs.Seek(Offset, SeekOrigin.Begin);
                    // download the chunks from the web service one by one, until all the bytes have been read, meaning the entire file has been downloaded.
                    while (Offset < plngFileSize)
                    {
                        int currentIntervalMod = numIterations % this.ChunkSizeSampleInterval;
                        if (currentIntervalMod == 0)
                            StartTime = DateTime.Now;	// used to calculate the time taken to transfer the first 5 chunks
                        else if (currentIntervalMod == 1)
                            CalcAndSetChunkSize(plngFileSize);
                        try
                        {
                            // although the DownloadChunk returns a byte[], it is actually sent using MTOM because of the configuration settings. 
                            byte[] Buffer = mobjService.DownloadChunk(pstrFileName, Offset, ChunkSize);
                            fs.Write(Buffer, 0, Buffer.Length);
                            Offset += Buffer.Length;	// save the offset position for resume
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("File not found") || NumRetries++ >= MaxRetries)	// too many retries, bail out
                            {
                                fs.Close();
                                return false;
                                //throw new Exception("Error occurred during upload, too many retries.\r\n" + ex.Message);
                            }
                        }
                        numIterations++;
                        //----------------------- Code Commented ------------------------
                        //lblDownload.Text = CalcFileSize(Offset) + " of " + strNewFileSize;
                        //lblRate.Text = CalcFileSize(ChunkSize)+"/sec";
                        ////pbrSummary.Value = (int)Offset;
                        ////if ((int)Offset <= pbrSummary.Maximum)
                        ////    pbrSummary.Value = (int)Offset;
                        ////else
                        ////    pbrSummary.Value = pbrSummary.Maximum;
                        //------------------------------------------------------------------
                    }
                }
                return true;
            }
            catch (Exception Exc)
            {
                throw (Exc);
            }
        }
        private void CalcAndSetChunkSize(long plngFileSize)
        {
            /* chunk size calculation is defined as follows 
             *		in the examples below, the preferred transfer time is 1500ms, taking one sample.
             *		
             *									  Example 1									Example 2
             *		Initial size				= 16384 bytes	(16k)						16384
             *		Transfer time for 1 chunk	= 800ms										2000 ms
             *		Average throughput / ms		= 16384b / 800ms = 20.48 b/ms				16384 / 2000 = 8.192 b/ms
             *		How many bytes in 1500ms?	= 20.48 * 1500 = 30720 bytes				8.192 * 1500 = 12228 bytes
             *		New chunksize				= 30720 bytes (speed up)					12228 bytes (slow down from original chunk size)
             */
            double transferTime = DateTime.Now.Subtract(this.StartTime).TotalMilliseconds;
            double averageBytesPerMilliSec = this.ChunkSize / transferTime;
            double preferredChunkSize = averageBytesPerMilliSec * this.PreferredTransferDuration;
            this.ChunkSize = (int)Math.Min(this.MaxRequestLength, Math.Max(4 * 1024, preferredChunkSize)) * 10;	// set the chunk size so that it takes 1500ms per chunk (estimate), not less than 4Kb and not greater than 4mb // (note 4096Kb sometimes causes problems, probably due to the IIS max request size limit, choosing a slightly smaller max size of 4 million bytes seems to work nicely)			
            //string statusMessage = String.Format("Chunk size: {0}{1}", CalcFileSize(this.ChunkSize), (this.ChunkSize == this.MaxRequestLength) ? " (max)" : "");
        }
