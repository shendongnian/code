    [Obsolete("Please use LatestGreatest instead.")]
    public class OldSchool
    {
        private LatestGreatest _Target;
        public OldSchool()
        {
            _Target = new LatestGreatest();
        }
        public void DoSomething()
        {
            _Target.DoSomething();
        }
        [Obsolete("Please use LatestGreatest.DoItInSomeOtherWay()")]
        public void DoTheOldWay()
        {
            _Target.DoItInSomeOtherWay();
        }
    }
    public class LatestGreatest
    {
        public void DoSomething()
        {
            Console.WriteLine("I'm so fresh and cool.");
        }
        public void DoItInSomeOtherWay()
        {
            Console.WriteLine("Let's do it...");
        }
    }
