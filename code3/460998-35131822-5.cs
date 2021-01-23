    IsSerialValid("edee-b8b7-9f6f-40ab", 17782415);
    
    public bool IsSerialValid(string serialCode, int ProductCode)
            {
                string SourceString = serialCode.Replace("-", "") + "|" + ProductCode.ToString() + "|" + "Alpha";
                byte[] data = Encoding.Default.GetBytes(SourceString);
                string Hash = Crypto.GenerateSHA256(data);
                if (Hash.StartsWith(GetDiff()))
                {
                    return true;
                }
                return false;
            }
