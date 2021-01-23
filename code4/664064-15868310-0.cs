    if (codes.Count() == 0)
    {
        codes = codesTemp.ToList();
    }
    else if (intersectionRequired)
    {
        codes = codes.Intersect(codesTemp, new ICD10Comparer()).ToList();
    }
    else
    {
        codes = codes.Union(codesTemp, new ICD10Comparer()).ToList();
    }   
