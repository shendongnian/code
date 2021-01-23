            var saml = string.Format(sample, Guid.NewGuid());
            var bytes = Encoding.UTF8.GetBytes(saml);
            string middle;
            using (var output = new MemoryStream())
            {
                using (var zip = new DeflateStream(output, CompressionMode.Compress))
                    zip.Write(bytes, 0, bytes.Length);
                
                middle = Convert.ToBase64String(output.ToArray());
            }
            // MIDDLE is the thing that should be now UrlEncode'd
            string decoded;
            using (var input = new MemoryStream(Convert.FromBase64String(middle)))
            using (var unzip = new DeflateStream(input, CompressionMode.Decompress))
            using (var reader = new StreamReader(unzip, Encoding.UTF8))
                decoded = reader.ReadToEnd();
            bool test = decoded == saml;
