        using System.Runtime.InteropServices.WindowsRuntime;
     
        private string GetSHA256Key(byte[] secretKey, string value)
        {
            var objMacProv = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
            var hash = objMacProv.CreateHash(secretKey.AsBuffer());
            hash.Append(CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8));
            return CryptographicBuffer.EncodeToBase64String(hash.GetValueAndReset());
        }
