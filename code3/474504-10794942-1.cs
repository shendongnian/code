    protected override void Dispose(bool disposing)
    {
        foreach (DataTable tab in this.Tables)
        {
            if (tab != null)
            {
                tab.Clear();
                tab.Columns.Clear();
                tab.Dispose();
            }
        }
        this.Tables.Clear();
        base.Dispose(disposing);
    }
