        class XAttributeEqualityComparer : IEqualityComparer<XAttribute>
        {
            public bool Equals(XAttribute x, XAttribute y)
            {
                return x.Name == y.Name; 
            }
            public int GetHashCode(XAttribute obj)
            {
                return obj.Name.GetHashCode(); 
            }
        }
