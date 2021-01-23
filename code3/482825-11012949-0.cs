        RijndaelManaged csp = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.ISO10126 };
        // TODO: define Key and IV
        Stopwatch encryptionTime = Stopwatch.StartNew();
        Parallel.For(0, 1000, i =>
            {
                string fieldValue = "abcdef...";
                byte[] fieldBytes = UTF8Encoding.UTF8.GetBytes(fieldValue);
                byte[] fieldEncrypred;
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, csp.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(fieldBytes, 0, fieldBytes.Length);
                    cs.FlushFinalBlock();
                    fieldEncrypred = ms.ToArray();
                }
            });
        encryptionTime.Stop();
        Console.WriteLine(encryptionTime.Elapsed.TotalMilliseconds);
