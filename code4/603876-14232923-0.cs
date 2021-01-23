    using System;
    using System.Text;
    
    public string RandomString (Random r, int len)
    {
    string str
    = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
    StringBuilder sb = new StringBuilder();
    
    while ((len--)> 0)
    sb.Append(str[(int)(r.NextDouble() * str.Length)]);
    
    return sb.ToString();
    }
