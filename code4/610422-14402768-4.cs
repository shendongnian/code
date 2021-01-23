    public class SomeState : StateBase
    {
        private SomeView my_view;
        public IView view
        {
            get { return (IView)SomeView; }
            set { ; }
        }
    }
    //program remains unchanged
