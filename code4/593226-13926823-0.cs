    string hexstr= "68696d616e736875";
    string subHexstr= hexstr.Substring(2,3); // Lets say index from 3rd byte to 5th byte.
    byte[] by=new byte[subHexstr.Length];
            int j = 0;
            for (int i = 0; i < by.Length; i++)
            {
                by[i] = byte.Parse(subHexstr.Substring(j, 2), System.Globalization.NumberStyles.HexNumber);
                j = j + 2;
            }
    if(by[0]!=0x00)
    { 
      string asciiStr= Encoding.Ascii.GetString(by);
    }
