    Private void fieldsSetter(string[] fieldnames, object[] items)
    {
    
        for(int s=0; s<fieldnames.Count(); s++)
        {
            SetField(fieldnames[s], (((item)items).FirstName == null || ((item)items).FirstName[0] == null) ? ""  : ((item)items).FirstName[0].Value);
        }
    }
