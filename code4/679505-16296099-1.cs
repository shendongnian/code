    public partial class Search : UserControl
        {
            public event EventHandler btnSearchClicked;
    
            public Search()
            {
                InitializeComponent();
            }
            private void btnsearch_Click(object sender, EventArgs e)
            {
    
               btnSearchClicked(sender, e);
            }
       }
