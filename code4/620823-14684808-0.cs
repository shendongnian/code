    public string plcIp
        {
            get
            {
                return _plcIp;
                OnPropertyChanged(); //This row..
            }
            set { _plcIp = value; }    
        }
