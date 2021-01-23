    string pw = "password1234";
    char[] splitpw;
    string cenpw;
    int NtoShow;
    splitpw = new char[pw.Length];
    splitpw = pw.ToCharArray();
    NtoShow = 4;
    for (int i = 0; i < pw.Length; i++)
    {
        if (i < pw.Length - NtoShow)
            cenpw += "*";
        else
            cenpw += splitpw[i];
    }
    
    //cenpw: "********1234"    
