    public partial class Form1 : Form
    {
        Form2 frm2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            if (frm2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.BackColor = frm2.formColor;
            frm2.Close();   
        }
    }
