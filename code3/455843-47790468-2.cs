        int Encode(string file, Encoding encode)
        {
            int retour = 0;
            try
            {
                using (var reader = new StreamReader(file))
                {
                    if (reader.CurrentEncoding != encode)
                    {
                        String buffer = reader.ReadToEnd();
                        reader.Close();
                        using (StreamWriter writer = new System.IO.StreamWriter(file, false, encode))
                        {
                            writer.Write(buffer);
                            writer.Close();
                        }
                        message = string.Format("Encode {0} !", file);
                        retour = 2;
                    }
                    else retour = 1;
                }
            }
            catch(Exception e)
            {
                message = string.Format("{0} ?", e.Message);
            }
            return retour;
        }
        /// <summary>
        /// Change encoding to UTF8
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public int toUTF8(string file)
        {
            return Encode(file, Encoding.UTF8);
        }
        public int toANSI(string file)
        {
            return Encode(file, Encoding.Default);
        }
