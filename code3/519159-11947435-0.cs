    void OnStartClicked(object sender, EventArgs e)
    {
       NotifyPropertyChanged("Devices");
    }
    public IEnumberable<Device> Devices
    {
       get 
       {
          if(string.IsNullOrEmpty(Filter)) return _devices;
          return _devices.Where(d => d.Satisfies(Filter));
          // or
          return _devices.Where(d => _filter.Satisfies(d, Filter));
       }
    }
