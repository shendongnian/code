    public class SelectListItemComparer : IEqualityComparer<SelectListItem>
    {
        public static SelectListItemComparer Instance = new SelectListItemComparer();
        private SelectListItemComparer() {}
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            return x.Value.Equals(y.Value);
        }
        public int GetHashCode(SelectListItem obj)
        {
            return obj.Value.GetHashCode();
        }
    }
