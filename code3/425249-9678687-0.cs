    void Main()
    {
        var items = new MyStruct[] { 
            new MyStruct { name = "item1", elements = new List<string> { "elementA" }},
            new MyStruct { name = "item2", elements = new List<string> { "elementA", "elementB" }}};
    
        var groupedByElement =
            from item in items
            from element in item.elements
            group item by element;
            
        groupedByElement.Dump(); // items grouped by element value, (pivoted)
        
        var elementsWithCount =
            from gj in groupedByElement
            select new { element = gj.Key, count = gj.Count() };
            
        elementsWithCount.Dump();
        // element, count
        // elementA, 2
        // elementB, 1
    }
    
    public struct MyStruct
    {
        public string name;
        public List<string> elements;
    }
