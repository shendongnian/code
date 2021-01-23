        private string GetBase64(string f)
        {
            string ret = "";
            {
                StreamResourceInfo sr = Application.GetResourceStream(new Uri(f, UriKind.Relative));
                using (BinaryReader br = new BinaryReader(sr.Stream))
                {
                    byte[] data = br.ReadBytes((int)sr.Stream.Length);
                    ret = System.Convert.ToBase64String(data);
                }
            }
            return ret;
        }
