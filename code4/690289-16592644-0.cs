    public VolumeLevel SelectedVolumeLevel
    {
        get { return selectedVolumeLevel; }
        set { selectedVolumeLevel = value; RaisePropertyChanged("SelectedVolumeLevel"); }
    }
