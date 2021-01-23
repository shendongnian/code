    string input = "000302A502B002B202B002B9000302BA02A502A702A902B9";
    byte[] bytes = new byte[input.Length/2];
    for (int i = 0; i < input.Length; i += 2){
        bytes[i / 2] = byte.Parse(input.Substring(i, 2), System.Globalization.NumberStyles.HexNumber); 
    }
    Encoding encode = Encoding.GetEncoding(1255);
    string output = encode.GetString(bytes);
