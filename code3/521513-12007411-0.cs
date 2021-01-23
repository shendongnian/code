    byte[] destTextBytes = Encoding.Convert(iso8859,unicode, srcTextBytes);
    char[] destChars = new char[unicode.GetCharCount(destTextBytes, 0, destTextBytes.Length)];
    unicode.GetChars(destTextBytes, 0, destTextBytes.Length, destChars, 0);
    System.String szchar = new System.String(destChars);
    MessageBox.Show(szchar);
