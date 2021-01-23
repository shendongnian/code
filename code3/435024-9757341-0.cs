    byte[] blob = new byte[input.Length / 2];
    for(int i = 0; i < blob.Length ; i++) {
        string pair = input.Substring(2 * i, 2);
        blob[i] = Convert.ToByte(pair, 16); // from hex to byte
    }
    string s = Encoding.Unicode.GetString(blob);
