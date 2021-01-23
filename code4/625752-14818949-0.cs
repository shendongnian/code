        //Get my objects and subscribe to their property change event
        MyObjects = GetMyObjects();
        foreach (var item in MyObjects)
        {
            item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
        }
        //Update Average whenever one of my items' Value property changes
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                UpdateAverage();
            }
        }
        //Update Average
        void UpdateAverage()
        {
            Average = MyObjects.Average(x.Value);
        }
        //Bind your textbox to this guy
        double _Average;
        public double Average
        {
            get { return _Average; }
            set
            {
                if (_Average != value)
                    OnNotifyPropertyChanged("Average");
            }
        }
