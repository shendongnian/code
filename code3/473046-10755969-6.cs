    private class PointsComparer : IComparer
    {
        private const int pointsColumnIndex = 1;
          
        public int Compare(object x, object y)
        {
            int pointsX = Int32.Parse(((ListViewItem)x).SubItems[pointsColumnIndex].Text);
            int pointsY = Int32.Parse(((ListViewItem)y).SubItems[pointsColumnIndex].Text);
            return pointsX.CompareTo(pointsY);
        }
    }
