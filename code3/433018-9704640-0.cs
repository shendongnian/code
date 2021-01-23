    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SortOrderAttribute : Attribute
    {
        private int _sortOrder;
        public SortOrderAttribute(int sortOrder)
        {
            _sortOrder = sortOrder;
        }
    }
