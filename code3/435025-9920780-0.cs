    enter code here
    As salamo alaikum wa rahmatullah,
    please find the code for converting hexa to Arabic.
    byte[] blob = new byte[text1.Text.Length / 2];
    for (int i = 0; i < blob.Length; i++)
    {
        string pair = text1.Text.Substring(2 * i, 2);
        blob[i] = Convert.ToByte(pair,16); // from hex to byte 
    }
    string s;//
    s = Encoding.BigEndianUnicode.GetString(blob);
    Label3.Text = s;
