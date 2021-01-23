    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        // When modifying the Text property it will change the text in textbox1
        public string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
