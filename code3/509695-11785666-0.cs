     private void AddEOFB(string imgFileName)
        {
            var fs = new FileStream(imgFileName, FileMode.Append, FileAccess.Write);
            try
            {
                fs.Seek(0, SeekOrigin.End);
                var buf = BitConverter.GetBytes(0x00100100);
                fs.Write(buf, 0, buf.Length);
            }
            catch { throw; }
            finally
            {
                fs.Close();
                fs.Dispose();
            }
        }
