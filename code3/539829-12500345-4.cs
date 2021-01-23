    public List<int> AllCodesList
    {
        get
        {
            var subDivisions = (from subdivision in SubdivisionInfoList
                                where subdivision.code > 0 
                                select subdivision.code).ToList();
            if (subDivisions.Count == 0)
            {
                subDivisions = null;
            }
            return subDivisions;
        }
    }
