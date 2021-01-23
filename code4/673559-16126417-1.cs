        public void SetScheduleCompletion()
       {
     .....
    //some code that knows when the schedule has been completed.
    //Now i know that this schedule has been completed so
    //push this to all the clients, ok then make the call back to the client hub proxy method
          Clients.All.updateScheduleStatus(responseObject); 
    //No i just want to send this to only specific clients. Ok then do this
       var subscribers = Clients.Group(someIdentifierToGetGroups);
       subscribers.updateScheduleStatus(responseObject);
    }
