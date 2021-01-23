    string strtext = "This is a very long text. this will come in one line.This is a very long text. this will come in one line.";
    if (strtext.Length > 32)
    {
       IEnumerable<string> strEnum = Split(strtext, 32);
       string a = string.Join("-\n", strEnum);
       if ((strtext.Length % 32)>0)
       {
          string lastpart = strtext.Substring(((strtext.Length / 32) * 32));
          a = a + "-\n" + lastpart;
       }
       label1.Text=a;
     }
