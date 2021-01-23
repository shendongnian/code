    public partial class Form1 : Form
    {
        public event Action PressLock;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Form2 dlg=new Form2();
            dlg.OtherFrom=this;            
            dlg.Show();
        }
        private void lockOnButton_Click(object sender, EventArgs e)
        {
            if(this.PressLock!=null)
            {
                this.PressLock();
            }
        }
    }
