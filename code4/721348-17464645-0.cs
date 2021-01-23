    public class PageBase
    {
        protected void DoSomething()
        {
        }
    }
    public class MyPage : PageBase
    {
        public void DoMore()
        {
            this.DoSomething();
            //and more..
        }
    }
