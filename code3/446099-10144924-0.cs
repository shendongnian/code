    public partial class MyControl : UserControl
    {
       public MyControl()
       {
          InitializeComponent();
          if (!DesignerProperties.GetIsInDesignMode(this))
          {
            //Do expensive operations here
          }
       }
    }
