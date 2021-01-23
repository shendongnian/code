    public class MemberServiceManager : ServiceClientBase<MemberServiceClient>
    {
        public int GetUserTypeFromProfileID(int profileID)
        {
            //makes a call to GetUserTypeFromProfileID operation, closes the channel and handles the exceptions
            //you may want to implement another base class for overriding exception handling methods
            //return value will be default of return type if any exceptions occur
            return PerformServiceOperation(item => item.GetUserTypeFromProfileID(profileID));
        }
        //or you can manually check if any exceptions occured with this overload
        public bool TryGetUserTypeFromProfileID(int profileID, out Profile profile)
        {
            return TryPerformServiceOperation(item => item.GetUserTypeFromProfileID(profileID), out profile);
        }
        
        //these exception handling methods should be overriden in another common subclass
        //they re-throw exceptions by default
        protected override void HandleCommunicationException(CommunicationException exception)
        {
            Console.WriteLine(exception.Message);
        }
        protected override void HandleFaultException(FaultException exception)
        {
            Console.WriteLine(exception.Message);
        }
        protected override void HandleTimeoutException(TimeoutException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
