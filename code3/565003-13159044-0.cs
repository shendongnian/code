    List<Byte> bytes = new List<Byte>();
    foreach (var splittedValue in hexString.Split(' ')) {
        bytes.Add(int.Parse(splittedValue, System.Globalization.NumberStyles.HexNumber));
    } 
    return bytes.ToArray();
