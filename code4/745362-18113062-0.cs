    if (childTable != null)
    {
       iBindingList = childTable.AsDataView() as IBindingList;
       iBindingList.ListChanged -= new ListChangedEventHandler(GridDataRecord_ListChanged);
       iBindingList.ListChanged += new ListChangedEventHandler(GridDataRecord_ListChanged);
    }
