    public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
    {
        if(IsGroupItem(outlineView, item))
        {
            return outlineView.MakeView("HeaderCell", this);
        }
        return outlineView.MakeView("DataCell", this);
    }
