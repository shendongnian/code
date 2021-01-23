    namespace TestSessionProgram
    {
        public class Program
        {
            public void Main()
            {
                ISession session1 = SessionMediator.CreateSession();
                ISession session2 = SessionMediator.CreateSession();
                ISession session3 = SessionMediator.CreateSession();
                SessionMediator.ActiveSession(session1)
                Thread.Sleep(2000);
                Debug.Assert(session1.DurationActive == TimeSpan.FromSeconds(2));
                SessionMediator.ActiveSession(session2)
                Thread.Sleep(3000);
                Debug.Assert(session2.DurationActive == TimeSpan.FromSeconds(3));
                SessionMediator.ActiveSession(session1)
                Thread.Sleep(3000);
                Debug.Assert(session1.DurationActive == TimeSpan.FromSeconds(5));
            }
        }
     
