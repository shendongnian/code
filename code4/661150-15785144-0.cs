    public class MeasConSettings : INotifyPropertyChanged
        {
    private ObservableCollection<DeviceDefinition> mDeviceDefinitionList;
    private DeviceDefinition mSelectedDeviceDefinition;
		
        public ObservableCollection<DeviceDefinition> DeviceDefinitionList
		{
			get
			{
				return mDeviceDefinitionList;
			}
			set
			{
				mDeviceDefinitionList = value;
			}
		}
        public DeviceDefinition SelectedDeviceDefinition
    		{
    			get
    			{
    				return mSelectedDeviceDefinition;
    			}
    			set
    			{
    				mSelectedDeviceDefinition = value;
    				NotifyPropertyChanged("SelectedDeviceDefinition");
    			}
    		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}
 
    }
