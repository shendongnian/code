        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 oFrm2 = new Form2();
            oFrm2.evtFrm += new ShowFrm(oFrm2_evtFrm);
            oFrm2.Show();
        }
        void oFrm2_evtFrm()
        {
            button1.Enabled = true;
        }
    }
