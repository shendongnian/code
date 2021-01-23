    public class SomeClassComparer : Comparer<SomeClass>
    {
        private TypeEnum _preference;
    
        public SomeClassComparer(TypeEnum preference)
            : base()
        {
            _preference = preference;
        }
    
        public override int Compare(SomeClass x, SomeClass y)
        {
            if (x.Name.Equals(y.Name))
            {
                return x.TypeEnum == y.TypeEnum ? 0
                    : x.TypeEnum == _preference ? -1
                    : y.TypeEnum == _preference ? 1
                    : x.TypeEnum == TypeEnum.Default ? -1
                    : y.TypeEnum == TypeEnum.Default ? 1
                    : x.TypeEnum.CompareTo(y.TypeEnum);
            }
            else
                return x.Name.CompareTo(y.Name);
        }
    }
