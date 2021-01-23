            var saml = string.Format(sample, Guid.NewGuid());
            var bytes = Encoding.UTF8.GetBytes(saml);
            string middle;
            using (var output = new MemoryStream())
            {
                using (var zip = new DeflaterOutputStream(output))
                    zip.Write(bytes, 0, bytes.Length);
                
                middle = Convert.ToBase64String(output.ToArray());
            }
            var bytes2 = new byte[bytes.Length];
            int read;
            using (var input = new MemoryStream(Convert.FromBase64String(middle)))
            using (var unzip = new InflaterInputStream(input))
                read = unzip.Read(bytes2, 0, bytes.Length);
            bool test1 = read == bytes.Length;
            bool test2 = bytes2.SequenceEqual(bytes);
            bool test3 = Encoding.UTF8.GetString(bytes2).Equals(saml);
