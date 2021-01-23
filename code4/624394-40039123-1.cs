            try
            {
               File.Copy(System.IO.Path.Combine(RecievedPath,fileName), System.IO.Path.Combine(SentPath,fileName));
                MessageBox.Show("File Copied");
            }
            catch (Exception)
            { }
        }
