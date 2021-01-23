     public BaseQueryClass
    {
        public string QueryClassFunc(string mystring, int i)
        {
            return mystring + i.ToString();
        }
    }
    public QueryClassDerived : BaseQueryClass
    {
        public string QueryClassFunc(string mystring)
        {
            return mystring;
        }
    }
