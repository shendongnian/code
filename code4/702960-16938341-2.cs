    List<String> list = new List<String>();
    list.Add("full1");
    list.Add("full1inc1");
    list.Add("full1inc2");
    list.Add("full1inc3");
    list.Add("full2");
    list.Add("full2inc1");
    list.Add("full2inc2");
    list.Add("full3");
    List<String> lines = new List<String>();
    foreach (String str in list)
    {
        String tmp = String.Empty;
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        foreach (Char ch in str.ToCharArray())
        {
            if (Char.IsLetter(ch))
            {
                if (!String.IsNullOrEmpty(sb2.ToString()))
                {
    	          tmp += sb2.ToString() + ",";
                    sb2 = new StringBuilder();
                }
                sb1.Append(ch);
            }
            else
            {
                if (!String.IsNullOrEmpty(sb1.ToString()))
                {
                    tmp += sb1.ToString() + ",";
                    sb1 = new StringBuilder();
                }
                sb2.Append(ch);
            }
        }
        if (!String.IsNullOrEmpty(sb1.ToString()))
            tmp += sb1.ToString() + ",";
        if (!String.IsNullOrEmpty(sb2.ToString()))
            tmp += sb2.ToString() + ",";
        lines.Add(tmp);
        for (Int32 i = 0; i < lines.Count; i++)
            lines[i] = lines[i].TrimEnd(',');
    }
