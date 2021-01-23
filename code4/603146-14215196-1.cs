    public partial class Form2 : Form
    {
      public string GetText { get {return txtForm2.Text;} }
      public Form2()
      {
        InitializeComponent();
      }
    
      public Form2(string textBoxValue)
      {
        InitializeComponent();
        this.txtForm2 = textBoxValue;
      }
    private void btnForm2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
