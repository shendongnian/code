    class a : System.UI.Page
    {
        protected int c = 0;
    }
    class b : a
    {
        protected void DoSomething()
        {
            c = 1; //Access c from derived class.
        }
    }
