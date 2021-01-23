    public string Data_Hex_Asc(ref string Data)
    {
        string Data1 = "";
        string sData = "";
        while (Data.Length > 0)
        //first take two hex value using substring.
        //then convert Hex value into ascii.
        //then convert ascii value into character.
        {
            Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Data.Substring(0, 2),  16)).ToString();
            sData = sData + Data1;
             Data = Data.Substring(2, Data.Length - 2);
        }
        return sData;
    }
