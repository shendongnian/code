    public class Test
    {
        XElement self;
        public Test(XElement self)
        {
            this.self = self;
        }
    
        public RSDataRow[] DataRows
        {
            get
            {
                if (null == _DataRows)
                {
                    _DataRows = self.GetEnumerable("rs:data/z:row", xrow => new RSDataRow(xrow)).ToArray();
                }
                return _DataRows;
            }
        }
        RSDataRow[] _DataRows;
    }
    
    [DebuggerDisplay("{Name}")]
    public class RSDataRow
    {
        XElement self;
        public RSDataRow(XElement self)
        {
            this.self = self;
        }
    
        public string Name
        {
            get { return self.Get("NAME", string.Empty); }
        }
    
        public string Description
        {
            get { return self.Get("DESCRIPTION", string.Empty); }
        }
    }
