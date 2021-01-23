    /// <summary>
    /// Create a dictionary of adjoinging walls keyed on a particular wall ID.
    /// </summary>
    /// <param name="document">Tje Revit API Document</param>
    /// <returns>A dictionary keyed on a wall id containing a collection of walls that adjoin the key id wall</returns>
    public IDictionary<ElementId,ICollection<Wall>> GetAdjoiningWallsMap(Document document)
    {
    	IDictionary<ElementId, ICollection<Wall>> result = new Dictionary<ElementId, ICollection<Wall>>();
    
    	FilteredElementCollector collector = new FilteredElementCollector(document);
    	collector.OfClass(typeof(Wall));
    	foreach (Wall wall in collector.Cast<Wall>())
    	{
    		IEnumerable<Element> joinedElements0 = GetAdjoiningElements(wall.Location as LocationCurve, wall.Id, 0);
    		IEnumerable<Element> joinedElements1 = GetAdjoiningElements(wall.Location as LocationCurve, wall.Id, 1);
    		result[wall.Id] = joinedElements0.Union(joinedElements1).OfType<Wall>().ToList();
    	}
    	return result;
    }
    
    private IEnumerable<Element> GetAdjoiningElements(LocationCurve locationCurve, ElementId wallId, Int32 index)
    {
    	IList<Element> result = new List<Element>();
    	ElementArray a = locationCurve.get_ElementsAtJoin(index);
    	foreach (Element element in a)
    		if (element.Id != wallId)
    			result.Add(element);
    	return result;
    }
