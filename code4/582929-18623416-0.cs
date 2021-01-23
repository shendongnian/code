        private static SecureString ConvertToSecureString(string encrypted, string header, byte[] key)
        {
            string[] strArray = Encoding.Unicode.GetString(Convert.FromBase64String(encrypted.Substring(header.Length, encrypted.Length - header.Length))).Split(new[] {'|'});
            SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create();
            int num2 = strArray[2].Length/2;
            var bytes = new byte[num2];
            for (int i = 0; i < num2; i++)
                bytes[i] = byte.Parse(strArray[2].Substring(2*i, 2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
            ICryptoTransform transform = algorithm.CreateDecryptor(key, Convert.FromBase64String(strArray[1]));
            using (var stream = new CryptoStream(new MemoryStream(bytes), transform, CryptoStreamMode.Read))
            {
                var buffer = new byte[bytes.Length];
                int num = stream.Read(buffer, 0, buffer.Length);
                var data = new byte[num];
                for (int i = 0; i < num; i++) data[i] = buffer[i];
                var str = new SecureString();
                for (int j = 0; j < data.Length/2; j++) str.AppendChar((char) ((data[(2*j) + 1]*0x100) + data[2*j]));
                return str;
            }
        }
