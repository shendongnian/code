    public partial class FormBase : Form   
    {
        public FormBase ()
        {
            this.InitializeComponent();
        }
        protected ConsistencyManager ConsistencyManager { get; private set; }
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if (this.ConsistencyManager == null)
            {
                this.ConsistencyManager = new ConsistencyManager(this);
                this.ConsistencyManager.MakeConsistent();
            }
        }
    }
