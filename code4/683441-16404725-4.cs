    public partial form1: System.Windows.Forms.Form
    {
       public form1()
       {
           InitializeComponent();
           MessageBox.Show(myUserControl1.TxtName.Text);
        
           MessageBox.Show(myUserControl1.CustomListBoxName.Items.Count);
           myUserControl1.DataSource = null;   
       }
    }
