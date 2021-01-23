    /// <summary>
    /// Get's the location coordinate of the specified column header's top/left corner
    /// </summary>
    /// <param name="oListView">ListView control to get the column header location from</param>
    /// <param name="iColumn">Column to find the location for</param>
    /// <param name="bAsScreenCoordinate">Whether the location returned is for the screen or the local ListView control</param>
    /// <returns>Location of column header or <see cref="Point.Empty"/> if it could not be retrieved</returns>
    public static Point GetColumnHeaderTopLeft(this ListView oListView, int iColumn, bool bAsScreenCoordinate) {
        if (oListView == null) {
            throw new ArgumentNullException();
        }
        if ((iColumn < 0) || (iColumn >= oListView.Columns.Count)) {
            throw new ArgumentOutOfRangeException();
        }
    
        // Get the header control's rectangle
        IntPtr hndHeader = NativeMethods.GetHeaderControl(oListView);
        Rectangle oHeaderRect = NativeMethods.GetHeaderItemRect(hndHeader, iColumn);
        if (oHeaderRect.IsEmpty) {
            return Point.Empty;
        }
    
        // Get the scroll bar position to adjust the left
        int iScroll = NativeMethods.GetScrollPosition(oListView, true);
    
        // Create the local coordinate
        Point oLocation = new Point(oHeaderRect.Left - iScroll, oHeaderRect.Top);
    
        // Return the local or screen coordinate
        return bAsScreenCoordinate ? oListView.PointToScreen(oLocation) : oLocation;
    }
