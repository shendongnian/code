        public class ViewModelSegments : BindableBase, INotifyPropertyChanged
        {
    
          private SegmentsCollection _segmentList = new SegmentsCollection();
          public SegmentsCollection SegmentList
          {
            get { return _segmentList; }
            set { SetProperty(ref _segmentList, value); }
          }
    
          //Bind this property to your ListView SelectedItem property in the xaml
          Segment _selectedSegment;
          public Segment SelectedSegment   
          {
            get
            {
               return _selectedSegment;
            }
            set
            {
               _selectedSegment=value;
               NotifyPropertyChanged("SelectedSegment");
            }
          }
          public event PropertyChangedEventHandler PropertyChanged;
          public void NotifyPropertyChanged(String propertyName)
          {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
       }
