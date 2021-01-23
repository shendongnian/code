    public String ValidationGroup
    {
        get { return RequiredFieldValidator1.ValidationGroup; }
        set { 
            RequiredFieldValidator1.ValidationGroup = value; 
            NewSchedule.ValidationGroup = value; 
        }
    }
