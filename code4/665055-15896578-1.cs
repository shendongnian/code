    public partial class frmMain : Form
    {
      private frmSettings settings = new frmSettings();
    
      public frmMain()
      {
        InitializeComponent();
      }
    
      private void button1_Click(object sender, EventArgs e)
      {
        UpdateForm();
      }
    
      private void UpdateForm()
      {
        comboBoxProducts.Items.Clear();
        comboBoxProducts.Items.AddRange(settings.GetProducts());
    
        dataGridView.Update();  
        //Other updates
      }
    }
