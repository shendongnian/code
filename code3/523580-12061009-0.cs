    int maxID=1;
    for each(var l in list)
    {
    if(int.Parse(l.ID.Replace("EMP_",""))>maxID)
    {
    maxID=int.Parse(l.ID.Replace("EMP_",""));
    }
    }
    maxID=maxID+1;
    
    string ID="EMP_"+maxID.Tostring();
