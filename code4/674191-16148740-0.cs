		/// <summary>
		/// Gets or sets SelectedDeviceName.
		/// </summary>
    	public ObservableCollection<string> DeviceNameList
	    {
			 get
		    {
			   return mDeviceNameList;
		    }
			set
			{
			   	mDeviceNameList = value;
			}
		}
		/// <summary>
		/// Gets or sets SelectedDeviceName.
		/// </summary>
		public string SelectedDeviceName
		{
			get
			{
				return mSelectedDeviceName;
			}
			set
			{
				mSelectedDeviceName = value;
				NotifyPropertyChanged("SelectedDeviceName");
			}
		}
        /// <summary>
		/// Event PropertyChanged
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
    		/// <summary>
		/// Function NotifyPropertyChanged
		/// </summary>
		/// <param name="property">
		/// The property.
		/// </param>
		private void NotifyPropertyChanged(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}
