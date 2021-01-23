    public string Encode(string input, byte [] key)
    {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes( input );
            MemoryStream stream = new MemoryStream( byteArray ); 
            byte[] hashValue = myhmacsha1.ComputeHash(stream);
            return hashValue.ToString();
    }
