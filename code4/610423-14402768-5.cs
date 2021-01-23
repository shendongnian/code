    public class BarState : StateBase
    {
        private BarView my_view;
        public IView view
        {
            get { return (IView)BarView; }
            set { ; }
        }
    }
    public class BarView : IView
    { ... }
