      public partial class Form1 : Form
      {
        private Form OtherForm { get; set; }
    
        private SwitchForms FormSwitcher { get; set; }
    
        public Form1()
        {
          InitializeComponent();
    
    
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
          OtherForm = new Form();
          OtherForm.Text = "Other Form";
          OtherForm.Show();
          OtherForm.Closed += OtherForm_Closed;
          FormSwitcher = new SwitchForms(this, OtherForm, 5.0);
        }
    
        void OtherForm_Closed(object sender, EventArgs e)
        {
          Show();
          //Application.Exit(); //Could also consider closing the app if the other window is closed
        }
    
      }
