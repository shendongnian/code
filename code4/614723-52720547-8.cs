    public partial class App : Application
    {
        public App()
        {
            // initiate it. Call it first.
            preventSecond();
        }
        private const string UniqueEventName = "{GENERATE-YOUR-OWN-GUID}";
        private void preventSecond()
        {
            try
            {
                EventWaitHandle.OpenExisting(UniqueEventName); // check if it exists
                this.Shutdown();
            }
            catch
            {
                new EventWaitHandle(false, EventResetMode.AutoReset, UniqueEventName); // register
            }
        }
    }
