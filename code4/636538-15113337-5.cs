    public class MainViewModel : ... , IHandle<LogInSuccessful>
    {
        ....
        public void Handle(LogInSuccessful message)
        {
            //here you can change the VM and access message.LoggedInAs string. 
            //This method will be called when there's an appropriate event published
            //to the same event aggregator that the MainViewModel is subscribed to.
        }
    }
