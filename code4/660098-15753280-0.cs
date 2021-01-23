    // For convenience add read-only property
    public sealed class BOM
    {
        ...
        public string PartAndQuantity { get{return Part + ", " + QtyPer;} }
    }
    // Group by FlatComponent and then use string.Join:
	var result = list.GroupBy (l => l.FlatComponent).Select(
		g => new 
		{
			Flat=g.Key, 
			Parts=string.Join(", ", g.Select (x => x.PartAndQuantity))
		});
