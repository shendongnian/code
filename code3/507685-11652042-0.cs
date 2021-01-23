        private bool TryCreateFile(string path)
        {
            try
            {
                FileStream fs = File.Create(path);
                fs.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }
