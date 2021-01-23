        public bool TransferFile(byte[] bytes, ref string token, ref string path, string extension)
        {
            string folderPath = string.Empty;
            if (System.Configuration.ConfigurationManager.AppSettings["DepositPath"] != null)
            {
                folderPath = System.Configuration.ConfigurationManager.AppSettings["DepositPath"].ToString();
            }
            if (string.IsNullOrEmpty(token))
            {
                token = Guid.NewGuid().ToString();
            }
            path = Path.Combine(folderPath, token + extension);
            
            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                stream.Close();
            }
            return true;
        }
