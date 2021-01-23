    private class PointsComparer : IComparer
    {
        private const int pointsColumnIndex = 1;
        private SortOrder _sortOrder;            
    
        public PointsComparer(SortOrder sortOrder)
        {
            _sortOrder = sortOrder;
        }
          
        public int Compare(object x, object y)
        {
            int pointsX = Int32.Parse(((ListViewItem)x).SubItems[pointsColumnIndex].Text);
            int pointsY = Int32.Parse(((ListViewItem)y).SubItems[pointsColumnIndex].Text);
            int comparisonResult = pointsX.CompareTo(pointsY);
    
            switch (_sortOrder)
            {
                case SortOrder.Ascending:
                    return comparisonResult;
                case SortOrder.Descending:
                    return (-1) * comparisonResult;
                default:
                    return 0;
            }
        }
    }
