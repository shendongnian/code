    public Model()
    {
        _Dates = new ObservableCollection<DateTime>();
        _Dates.CollectionChanged += (s, e) =>
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs("DatesAfterToday"));
                }
            };
    }
