    public class Bar : IFoo {
        
        private IList<int> _integers;
        
        IEnumerable<int> IFoo.integers {
            get { return _integers };
            set { _integers = value as IList<int>; }
        }
        
        public IList<int> integers {
            get { return _integers; }
            set { _integers = vale; }
        }
    }
