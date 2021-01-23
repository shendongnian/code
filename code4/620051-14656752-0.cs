        public class ViewModelSegments : BindableBase
        {
    
          private SegmentsCollection _segmentList = new SegmentsCollection();
          public SegmentsCollection SegmentList
          {
            get { return _segmentList; }
            set { SetProperty(ref _segmentList, value); }
          }
    
          //Bind this property to your ListView SelectedItem property in the xaml
          public Segment SelectedSegment   
          {
            get;set;
          }
       }
