    public class UserControlData
    {
        public ReadOnlyObservableCollection<DataTypeOne> DataOneItems
        {
            get
            {
                ObservableCollection<DataTypeOne> dataOneItems = new ObservableCollection<DataTypeOne>();
                for (int i = 1; i <= 3; i++)
                    dataOneItems.Add(new DataTypeOne(i));
                return new ReadOnlyObservableCollection<DataTypeOne>(dataOneItems);
            }
        }
    
        public ReadOnlyObservableCollection<DataTypeTwo> DataTwoItems
        {
            get
            {
                ObservableCollection<DataTypeTwo> dataTwoItems = new ObservableCollection<DataTypeTwo>();
                for (int i = 1; i <= 3; i++)
                    dataTwoItems.Add(new DataTypeTwo(i));
    
                return new ReadOnlyObservableCollection<DataTypeTwo>(dataTwoItems);
            }
        }
    
        public bool ShowVertically
        {
            get;
            set;
        }
    }
