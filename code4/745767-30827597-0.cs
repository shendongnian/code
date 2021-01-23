    public class GenericNumericComparer : ICustomSorter
    {
        private PropertyInfo _propertyInfo;
        private Type _objectType;
        public string SortMemberPath { get; set; }
        private readonly NumericComparer _comparer = new NumericComparer();
        public Type ObjectType
        {
            get { return _objectType; }
            set
            {
                _objectType = value;
                if (_objectType != null) _propertyInfo = ObjectType.GetProperty(SortMemberPath);
            }
        }
        private int CompareHelper(object x, object y)
        {
            if (_propertyInfo != null)
            {
                var value1 = _propertyInfo.GetValue(x);
                var value2 = _propertyInfo.GetValue(y);
                return _comparer.Compare(value1, value2);
            }
            return 0;
        }
        public int Compare(object x, object y)
        {
            var i = CompareHelper(x, y);
            if (SortDirection == ListSortDirection.Ascending)
                return i;
            return i*-1;
        }
        public ListSortDirection SortDirection { get; set; }
    }
