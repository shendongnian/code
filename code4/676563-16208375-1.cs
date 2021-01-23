    public abstract class MockDataBase
    {
        private string _ExxternalID;
    
        public virtual string ExxternalID
        {
            get { return _ExxternalID; }
            protected set { _ExxternalID = value; }
        }
    }
    public class UnitMockDataBase : MockDataBase
    {
        public override string ExxternalID
        {
            get
            {
                return base.ExxternalID;
            }
            protected set
            {
                base.ExxternalID = value;
            }
        }
    }
