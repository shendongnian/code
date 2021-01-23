    public DateTime? DatumNabavke
    {
        get { 
			if( _datumNabavke == null)
				 return DateTime.Now;
				 
			return _datumNabavke; 
		}
        set { _datumNabavke = value; OnPropertyChanged("DatumNabavke"); }
    }
