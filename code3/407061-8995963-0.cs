    string ByteArrayToString(byte[] arr)
    {
        char[] charArray = arr.Select(b => (char)b).ToArray();
        return new string(charArray);
    }
    byte[] StringToByteArray(string s)
    {
        //this method maps each char in the string to a single output byte;
        //all chars should be in the range 0 to 255.  The checked 
        //conversion will catch any data that violates this requirement.
        return s.Select(c => checked ( (byte)c )).ToArray();
    }
