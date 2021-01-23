    public DateTime? DueDate
    {
        //Need to change the type of the private variable as well
        get { return dueDate; }
        set
        {
            if (DueDate != null) || !DueDate.Equals(value))
            {
                dueDate = value;
                OnPropertyChanged("DueDate");
            }
        }
    }
