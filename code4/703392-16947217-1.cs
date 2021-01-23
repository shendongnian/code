    ...
    MyDataClass.NewEvent += OneOfSubscriberClassInstance.OnNewEvent;
    
    ...
    public void OnNewEvent(object sender, YourEventArgs args)
    { 
       Task.Factory.StartNew( () => {
    
           // all your event handling code here 
       });
    }
