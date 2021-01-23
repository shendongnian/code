        static void ExtractFileResource(string resource_name, string file_name)
        {
            try
            {
                if (File.Exists(file_name))
                    File.Delete(file_name);
                if (!Directory.Exists(Path.GetDirectoryName(file_name)))
                    Directory.CreateDirectory(Path.GetDirectoryName(file_name));
                using (Stream sfile = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource_name))
                {
                    byte[] buf = new byte[sfile.Length];
                    sfile.Read(buf, 0, Convert.ToInt32(sfile.Length));
                    using (FileStream fs = File.Create(file_name))
                    {
                        fs.Write(buf, 0, Convert.ToInt32(sfile.Length));
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can't extract resource '{0}' to file '{1}': {2}", resource_name, file_name, ex.Message), ex);
            }
        }
