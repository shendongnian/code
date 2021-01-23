    public ObservableCollection<JobItem> FilteredJobItemList
    {
       get
       {
          if ((IsActiveChecked) && (!IsCompletedChecked))
          {
              return JobItemList.Where(x => x.status != "Completed");
          }
          else if ((!IsActiveChecked) && (IsCompletedChecked))
          {
              return JobItemList.Where(x => x.status == "Completed");
          }
          else
          {
              return JobItemList;
          }
       }
    }
    
    public bool IsActiveChecked
    {
       get
       {
          return _isActiveChecked;
       }
       set
       {
          if (value != _isActiveChecked)
          {
              _isActiveChecked = value;
              OnPropertyChanged("IsActiveChecked");
              OnPropertyChanged("FilteredJobItemList");
          }
       }
    } 
    public bool IsCompletedChecked
    {
       get
       {
          return _isCompletedChecked;
       }
       set
       {
          if (value != _isCompletedChecked)
          {
              _isCompletedChecked = value;
              OnPropertyChanged("IsCompletedChecked");
              OnPropertyChanged("FilteredJobItemList");
          }
       }
    } 
     
