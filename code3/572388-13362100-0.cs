    public void GetGenderInfo()
    {
        List<Gender> lstGenders = GetListOfGenders();
    
        var tmpDict = new Dictionary<int, List<Gender>();
        foreach (var g in lstGenders)
        {
            List<Gender> currGender;
            if (!tempDict.TryGetValue(g.GenderId, out currGender)
            {
                currGender = new List<Gender>();
                tempDict.Add(g.GendrId, currGender);
            }
            currGender.Add(g);
         }
    
        //Now itterate your dictionary & pull out the groupings.
        }
