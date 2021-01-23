    // Auto resize of ListView Columns to minimum width
    private int[] ColumnsWidth = { 35, 322 };
    /// <summary>
    /// Resize the columns based on the items entered
    /// </summary>
    private void ResizeColumns()
    {
        // Auto Resize Columns based on content
        m_urlsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        // Make sure to resize to minimum width
        if (m_urlsListView.Columns[0].Width < ColumnsWidth[0])
        {
            m_urlsListView.Columns[0].Width = ColumnsWidth[0];
        }
        if (m_urlsListView.Columns[1].Width < ColumnsWidth[1])
        {
            m_urlsListView.Columns[1].Width = ColumnsWidth[1];
        }
    }
