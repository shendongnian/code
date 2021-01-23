    [HttpPost]
        public void Base64ToImage(string source)
        {
            string base64 = source.Substring(source.IndexOf(',') + 1);
            base64 = base64.Trim('\0');
            byte[] chartData = Convert.FromBase64String(base64);
    }
