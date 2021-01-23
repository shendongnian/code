    // Shared interface for shared properties.
    // Also change FindAll to return a List<IDrillType>.
    interface IDrillType { int RunID { get; } }
    class TCHEMISTRY : IDrillType { ... }
    class TDRILLSPAN : IDrillType { ... }
    // Getter dictionary rather than type dictionary.
    Dictionary<int, Func<List<IDrillType>>> DrillTypeGetters =
        new Dictionary<int, Func<List<IDrillType>>>()
        {
            { 13, TCHEMISTRY.FindAll },
            { 14, TDRILLSPAN.FindAll }
        };
    List<IDrillType> LC = DrillTypeGetters[13]();
    IEnumerable<IDrillType> LingLC = 
        from obj in LC where obj.RunID == 1001 select obj;   
    
