    public DateTime? SomeDate
    {
        get { return someDate; }
        set
        {
            if (someDate != value)
            {
                if (!(value == null && someCondition))
                    someDate = value;
                else
                   TellTheUserHeCannotClearTheField();  //Optional?
                NotifyPropertyChanged(() => SomeDate);
            }
        }
    }
