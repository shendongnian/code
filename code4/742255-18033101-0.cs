    byte[] b1 = System.Text.Encoding.ASCII.GetBytes(myCookie.ToString());
    string str1 = Convert.ToBase64String(b1);
    
    byte[] b2 = Convert.FromBase64String(str1);
    string str2 = System.Text.Encoding.ASCII.GetString(b2);
