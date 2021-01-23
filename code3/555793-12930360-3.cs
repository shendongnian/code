    // Getter dictionary rather than type dictionary.
    Dictionary<int, Func<IEnumerable<object>>> DrillTypeGetters =
        new Dictionary<int, Func<IEnumerable<object>>>()   
        {  
            { 13, () => TCHEMISTRY.FindAll().Cast<object>() },
            { 14, () => TDRILLSPAN.FindAll().Cast<object>() }
        };
    Dictionary<int, Func<object, int>> IDGetters =
        new Dictionary<int, Func<object, int>>()
        {
            { 13, o => ((TCHEMISTRY)o).RunID },
            { 13, o => ((TDRILLSPAN)o).RunID }
        };
    IEnumerable<object> LC = DrillTypeGetters[13]();
    IEnumerable<object> LingLC = 
        from obj in LC
        where IDGetters[13](obj) == 1001
        select obj;
