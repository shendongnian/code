    public class MainView : IMainView
    {
        IMainPresenter _presenter;
        public MainView()
        {
           _presenter = new MainPresenter(this);
        }
    }
