    public class MyForm : Form
    {
        MyOtherForm OtherForm;
        public MyForm()
        {
            InitializeComponent();
            OtherForm = new MyOtherForm();
            OtherForm.ButtonINeedToListenFor.Click += new EventHandler(ButtonINeedToListenFor_Click);
        }
        
        void ButtonINeedToListenFor_Click(object sender, EventArgs e)
        {
             this.MyDependingButton.Enabled = false;
        }
    }
