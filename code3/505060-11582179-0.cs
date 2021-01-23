    class DerivedControl : BaseControl
    {
         public DerivedControl()
            : base()
        {
                
        }
    }
    
    class BaseControl : UserControl
    {
         public BaseControl ()
        {
            InitializeComponent(); // makes the panel visible by default
            IsTitlePanelVisible = false // makes the panel hidden explicity
        }
    }
