    string abc = "15k34";
    int x = 0;
    //abc = "05k34";
    int val;
    if (!string.IsNullOrEmpty(abc) && abc.Length > 1)
    {
        bool isNum = int.TryParse(str.Substring(0, 2), out val);
        if (isNum)
        {
            x = val;
        }
    }
