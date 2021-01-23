    public Employee SelectedEmployee
    { 
         get { return selectedEmployee; }
         set
         {
             if (selectedEmployee != value)
             {
                 selectedEmployee = value;
                 LastName = value;
                 NotifyPropertyChanged("SelectedEmployee"); //NotifyPropertyChanged("SelectedItem");
             }
          }
    }
