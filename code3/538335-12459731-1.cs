    public partial class FrmZigndSC : Form
    {
        public FrmZigndSC()
        {
            InitializeComponent();
    
            this.KeyPress += (s, e) => this.LblResult.Text += e.KeyChar.ToString();
    
            // this might be a solution, but i did not need it
            this.Shown += (s, e) => this.Activate();
        }
    }
