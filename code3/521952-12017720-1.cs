        List<String> strlist = new List<string>();
        strlist.Add("st1");
        strlist.Add("st2");
        strlist.Add("st3");
        var dynamicPart = string.Join(", ",
         Enumerable.Range(0, strlist.Count).Select(i => "@" + i).ToArray());
        for(i = 0 to strlist.Count)
         { /* add parameter to SqlCommand here with name ("@" + i) */ }
        string query = "SELECT Column1 FROM Table1 WHERE Column1 IN (" +
         dynamicPart + ")";
