        private string GetFileSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";
            return size;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                FileInfo thisFile = new FileInfo(openFile1.FileName);
                string info = "";
                info += "File: " + Path.GetFileName(openFile1.FileName);
                info += Environment.NewLine;
                info += "File Size: " + GetFileSize((int)thisFile.Length);
                label1.Text = info;
            }
        }
