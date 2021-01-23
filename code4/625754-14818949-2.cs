        //Bind your textbox to this guy
        double _Average;
        public double Average
        {
            get { return _Average; }
            set
            {
                if (_Average != value)
                {
                    _Average = value;
                    OnNotifyPropertyChanged("Average");
                }
            }
        }
