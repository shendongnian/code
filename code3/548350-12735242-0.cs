    // Condition 2:
    // Get the characters of in list B that contains the "999" string. 
    var badOnes = ListB.Where(s=>s.Contains("999").Select(s=>s[0])
    
    // If there is any forbidden characters remove them from List A
    if (badOnes.Length > 0)
    {
        ListA.RemoveAll(x => x[0] == badOnes.Exists(c => c == x));
    }
    
    // Condition 1:
    if (ListA.Distinct().Intersect(ListB).Length == ListA.Distinct().Length)
    {
        return true;
    }
