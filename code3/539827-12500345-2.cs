    public List<int> AllCodesList
    {
        get
        {
            List<int> subDivisions = null;
    		var temp = (from subdivision in SubdivisionInfoList
                    where subdivision.code > 0 
                    select subdivision.code).ToList();
            if (temp.Count() > 0) // This might have to just be temp.Count, I did this code in Notepad++.
            {
                subDivisions = temp;
            }
            return subDivisions;
        }
    }
