    public class ViewController
    {
        private View _view;
        private ViewModel _viewModel;
        public ViewController()
        {
            ICommand closeView = new DelegateCommand(m => closeView());
            this._view = new View();
            this._viewModel = new ViewModel(closeView);
            this._view.DataContext = this._viewModel;
        }
        private void closeView()
        {
            this._view.close();
        }
    }
    public class ViewModel
    {
        private bool _viewModelClosing;
        
        public ICommand CloseView { get;set;}
        
        public bool ViewModelClosing
        { 
            get { return this._viewModelClosing; }
            set
            {
                if (value != this._viewModelClosing)
                {
                    this._viewModelClosing = value;
                    // odd to do it this way.
                    // better bind a button event in view 
                    // to the ViewModel.CloseView Command
                    
                    this.closeCommand.execute();
                }
            }
        }
        public ViewModel(ICommand closeCommand)
        {
            this.CloseView = closeCommand;
        }
    }
