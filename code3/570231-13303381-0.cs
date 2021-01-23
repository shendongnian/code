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
                if (x.TypeEnum == y.TypeEnum)
                    return 0;
                else if (x.TypeEnum == _preference)
                    return -1;
                else if (y.TypeEnum == _preference)
                    return 1;
                else if (x.TypeEnum == TypeEnum.Default)
                    return -1;
                else if (y.TypeEnum == TypeEnum.Default)
                    return 1;
                else
                    return x.TypeEnum.CompareTo(y.TypeEnum);
            }
            else
                return x.Name.CompareTo(y.Name);
        }
    }
