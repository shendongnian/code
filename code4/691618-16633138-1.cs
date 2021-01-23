        public delegate void ShowFrm();
        public partial class Form2 : Form
        {
        public event ShowFrm evtFrm;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (evtFrm != null)
            {
                evtFrm();
            }
        }
    }
