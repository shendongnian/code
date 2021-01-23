    public partial class Form2 : Form
    {
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.Parent = parent;
        }
        Form1 Parent;
        private void button1_Click(object sender, EventArgs e)
        {
            Parent.pictureBox.Visible= true;
        }
        ...
    }
