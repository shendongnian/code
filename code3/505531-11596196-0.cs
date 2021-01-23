    private string assignedClearProgram;
    public string AssignedClearProgram
    {
       get { return assignedClearProgram; }
       set
       {
           if (assignedClearProgram != value)
           {
               assignedClearProgram = value;
    
               // Notify property has changed here using PropertyChanged event from INotifyPropertyChanged.
           }
       }
    }
