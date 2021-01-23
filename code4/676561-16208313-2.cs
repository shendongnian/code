    public class UnitMockDataBase: MockDataBase
    {
        private string _externalId;
        public override string ExternalId 
        {
            get { return _externalId; } } 
            set { _externalId = value; } }
    }
