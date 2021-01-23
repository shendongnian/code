                DirectoryInfo DI = new DirectoryInfo(@"D:\TimeQImages\");
            if (DI.Exists)
            {
                progressBar1.Value = 0;
                FileInfo[] fi = DI.GetFiles();
                int size = fi.Length;
                if (size < 100)
                {
                    size = 100 / size;
                }
                else
                {
                    size = (int)(size / 100);
                }
                foreach (FileInfo f in fi)
                {
                    progressBar1.Value += size;
                    ConvertToChunks(f.FullName);                     
                    f.Delete();
                }
                MessageBox.Show("Transfer completed");
            }
