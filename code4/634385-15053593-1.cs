    [ServiceBehavior(UseSynchronizationContext = false)]
    public class WCF : IWCF
    {
        public string DoWork()
        {
            return " Hello There! ";
        }
    }
