    public void Process(EventDto eventDto)
    {
       //Do nothing
       if (eventDto is EventDtoSubclass1)
       {
           // do something   
       }
       else if (eventDto is EventDtoSubclass2)
       {
           // do something else
       }
    }
