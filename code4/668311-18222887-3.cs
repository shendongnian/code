    public class FooConvention : IMemberMapConvention
    
        private string _name = "FooConvention";
        #region Implementation of IConvention
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberName == "Text")
            {
                memberMap.SetElementName("NotText");
            }
        }
        #endregion
    }
