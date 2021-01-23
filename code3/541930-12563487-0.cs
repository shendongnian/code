    var doc = XDocument.Parse(xml);
	
    var comparer = new ElementsComparer();
   
    doc.Descendants("B")
       .GroupBy(x => x.Parent)
       .Distinct(comparer)
       .Dump();
    class ElementsComparer : IEqualityComparer<IGrouping<XElement, XElement>>,
                             IEqualityComparer<XElement>
    {
        public bool Equals(XElement lhs, XElement rhs)
        {
            return lhs.Value.Equals(rhs.Value);
        }
        
        public bool Equals(IGrouping<XElement, XElement> lhs,
                           IGrouping<XElement, XElement> rhs)
        {
            var x = lhs.OrderBy(a => a.Value);
            var y = rhs.OrderBy(a => a.Value);
            return x.SequenceEqual(y, this);
        }
    
        public int GetHashCode(XElement obj)
        {
            return obj.Value.GetHashCode();
        }
        
        public int GetHashCode(IGrouping<XElement, XElement> obj)
        {
            return 0;
        }
    }
