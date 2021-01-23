    public class ExtenalLibWrapper
    {
        private static object Locker = new object();
        
        public void DoSomething(LoginDetails details)
        {
            lock(Locker)
            {
                ExternalLib.SetLoginData(login.Schema, login.User, login.pass);
                ExternalLib.PerformTask();
            }
        }
    }
