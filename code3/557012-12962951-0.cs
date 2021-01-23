    byte[] buf = File.ReadAllBytes(file);
    var str = new SoapHexBinary(buf).ToString();
    //str=89504E470D0A1A0A0000000D49484452000000C8000000C808030000009A865EAC00000300504C544......
    //Do your work
    File.WriteAllBytes(file,SoapHexBinary.Parse(str).Value);
