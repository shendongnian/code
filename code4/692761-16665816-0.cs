        public static string readFileContent(String filename)
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
                    return sr.ReadToEnd();
            }
            catch { return String.Empty; }
        }
