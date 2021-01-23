    public class UnitMockDataBase: MockDataBase
    {
        private string _externalId;
        public override string ExternalId { set { _externalId = value; } }
    }
