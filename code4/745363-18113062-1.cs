    bool listChangedSubscribed = false;  
    if (childTable != null)
    {
       iBindingList = childTable.AsDataView() as IBindingList;
       iBindingList.ListChanged -= new ListChangedEventHandler(GridDataRecord_ListChanged);
       if(!listChangedSubscribed)
       {
           iBindingList.ListChanged += new ListChangedEventHandler(GridDataRecord_ListChanged);
           listChangedSubscribed = true; 
       }
