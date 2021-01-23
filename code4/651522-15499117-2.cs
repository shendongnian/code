    public class CameraComparer : IComparer<Camera>
    {
        private SortDirection typeSortDirection;
        private SortDirection nameSortDirection;
        public CameraComparer(SortDirection typeSortDirection, 
                              SortDirection nameSortDirection)
        {
            this.typeSortDirection = typeSortDirection;
            this.nameSortDirection = nameSortDirection;
        }
        public int Compare(Camera x, Camera y)
        {
            if (x.Type == y.Type)
                return x.Name.CompareTo(y.Name) * 
               (nameSortDirection == SortDirection.Ascending ? 1 : -1);
            return x.Type.CompareTo(y.Type) * 
               (typeSortDirection == SortDirection.Ascending ? 1 : -1);
        }
    }
    public enum SortDirection
    {
        Ascending,
        Descending
    }
