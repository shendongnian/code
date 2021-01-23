        private string GetHtmlFromResponse(HttpWebResponse response)
        {
            string sFicha = null;
            using (Stream s = response.GetResponseStream())
            {
                Encoding eCodificacion = Encoding.GetEncoding(response.CharacterSet);
                StreamReader sr = new StreamReader(s, eCodificacion);
                sFicha = sr.ReadToEnd();
                sr.Close();
            }
            return sFicha;
        }
