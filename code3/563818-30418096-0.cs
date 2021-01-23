    readonly Dictionary<Control, string> _groupNames = new Dictionary<Control, string>();
    private Group _lastGroup;
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var obj = (Obj)e.Row.DataItem;
            if (obj.Group != _lastGroup)
            {
                e.Row.SetRenderMethodDelegate(RenderGridViewRowWithHeader);
                _lastGroup = obj.Group;
                // Cache group description for this row, note that you might
                // like to implement this differently if you have your data normalized.
                _groupNames[e.Row] = obj.Group.Description;                 }
            }
        }
    }
