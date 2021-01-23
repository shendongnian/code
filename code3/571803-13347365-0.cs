    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            switch (name)
            {
                case "YearsToSave":
                    Questions.NumberOfYears = YearsToSave;
                    handler(this, name);
                    break;
            }
        }
    }
