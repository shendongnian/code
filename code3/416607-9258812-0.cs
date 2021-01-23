    for(int i = 0; i < list.Count; i++)
    { 
        string x= list[i].ToString();
        foreach(string y in x.Split(':'))
        {
            // do something with y
        }
    }
