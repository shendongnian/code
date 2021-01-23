    public class Locator
    {
        private MainViewModel _model;
 
        public MainViewModel Main
        {
            get
            {
                if (_model == null) _model = new MainViewModel();
                return _model;
            }
        }
    }
