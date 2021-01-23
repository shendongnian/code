      public partial class ValidationUserControl : UserControl
        {
            public ValidationUserControl()
            {
                InitializeComponent();
                this.DataContext = new ValidationViewModel();
                
            }
    
        }
