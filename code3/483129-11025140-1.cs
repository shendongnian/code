    ObservableCollection<AppointmentDTO> _appointments;
    public ObservableCollection<AppointmentDTO> Appointments
    {
        get
        {
            return _appointments;
        }
        set
        {
            if (_appointments != value)
            {
                if (_appointments != null)
                    _appointments.CollectionChanged -= Appointments_CollectionChanged;
                _appointments = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HasSchedule"));
                if (_appointments != null)
                    _appointments.CollectionChanged += Appointments_CollectionChanged;
            }
        }
    }
    void Appointments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs("HasSchedule"));
    }
