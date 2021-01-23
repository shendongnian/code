    var typeInfo = LC.GetType();
    IEnumerable<T> genericList;
    if (typeInfo == typeof(IEnumerable<TChemistry>)
    {
        genericList = (List<TChemistry>) LC;
    )
    else if (typeInfo == typeof(IEnumerable<TDrillSpan>)
    {
        genericList = (List<TDrillSpan>) LC;
    }
    
    var LingLC = from obj in genericList where obj.RunID == 1001 select obj;
