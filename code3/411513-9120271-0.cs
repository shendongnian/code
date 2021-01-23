    public partial class Form1 : Form
    {
        Form2 frm2 = new Form2();
    
        public Form1()
        {
            InitializeComponent();
            frm2.VisibleChanged += frm2_VisibleChanged;
            Shown += Form1_Shown;
        }
    
        void Form1_Shown(object sender, EventArgs e)
        {
            frm2.ShowDialog();
        }
    
        void frm2_VisibleChanged(object sender, EventArgs e)
        {
            if (frm2.Visible == false) Hide();
        }
    }
