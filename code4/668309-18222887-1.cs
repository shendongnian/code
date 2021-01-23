    public class FooConvetion : IMemberMapConvention
    {
        private string _name = "FooConvetion";
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
