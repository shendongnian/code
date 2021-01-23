    [ContractClassFor(typeof(ICC4))]
    public abstract class ICC4Contract : ICC4
    {
        public bool IsFooSet
        {
            get
            {
                Contract.Ensures(Contract.Result<bool>() == (Foo != null));
                return false;
            }
        }
        public string Foo
        {
            get { return null; } // no contract needed
        }
    }
