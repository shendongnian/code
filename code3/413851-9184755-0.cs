    // I don't know what the proper signature is for a SavingChanges event handler
    public class EventHandlers
    {
        public static void SavingChangesHandler(object sender, EventArgs args)
        {
          // do something with sender and args here
        }
    }
    
    
    // in your other code
    SomeObject.SavingChanges += EventHandlers.SavingChangesHandler;
