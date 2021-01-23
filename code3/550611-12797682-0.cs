     public partial class Form1 : Form
    {
        public string name = "something";
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void nameChanger(string nme);
        public void ChangeName(string nme)
        {
            this.name = nme;
        }
        public void SafeNameChange(string nme)
        {
            this.Invoke(new nameChanger(ChangeName), new object[] { nme });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.Show();
        }
}
 
    public partial class Form2 : Form
        {
            Form1 ff;
            public Form2(Form1 firstForm)
            {
                InitializeComponent();
                ff = firstForm;
            }
        private void button2_Click(object sender, EventArgs e)
        {
            ff.SafeNameChange("something different from the Form1");
            this.Close();
        }
    }
