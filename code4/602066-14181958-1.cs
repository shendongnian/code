    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            var owner = this.Owner as Form1;
            var val = owner.SomeProperty;
            MessageBox.Show(val); //Shows a MessageBox with 'HELLO WORLD'
        }
    }
