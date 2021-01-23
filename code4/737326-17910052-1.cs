    public partial class ResourceControl : UserControl
    {
        public ResourceControl()
        {
            InitializeComponent();
        }
    }
    public class MyLabel : Label 
    {
        public MyLabel() 
        {
            base.OnApplyTemplate();
        }   
    }
