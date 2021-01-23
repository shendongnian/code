    public class PropertyInfoComparer : IComparer<PropertyInfo>
    {
        public int Compare(PropertyInfo a, PropertyInfo b)
        {
            return a.GetCustomAttributes(typeof(SortOrderAttribute), false)[0] - b.GetCustomAttributes(typeof(SortOrderAttribute), false)[0];
        }
    }
