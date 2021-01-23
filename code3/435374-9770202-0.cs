    public partial class BaseView   : Window
    {
        BaseViewModelTech  viewModel; 
        
        public BaseView  (BaseViewModelTech   vm)
        {
            InitializeComponent();
            viewModel = vm;
            this.DataContext = vm;   // <----------- add this
        }
    }
