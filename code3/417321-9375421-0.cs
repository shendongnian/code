    public partial class Form1 : Form
    {
        Form f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            f2.Show();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ClientRectangle.Contains(e.Location) && f2.Visible) { f2.Hide(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f2.Visible = !f2.Visible ? true : false;
        }
    }
