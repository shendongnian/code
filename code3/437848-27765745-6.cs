    public partial class Form1 : Form
    {
        public SimpleViewModel ViewModel = new SimpleViewModel();
        public Form1()
        {
            InitializeComponent();
            this.panel1.Visible = false;
            this.bindingSource1.DataSource = this.ViewModel;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HackIt();
        }
        void HackIt()
        {
            this.SuspendLayout();
            foreach(Control control in this.Controls)
            {
                var v = control.Visible;
                control.Visible = true;
                foreach(Binding db in control.DataBindings)
                {
                    db.ReadValue();
                }
                control.Visible = v;
            }
            this.ResumeLayout();
        }
    }
