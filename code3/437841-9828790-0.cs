    public partial class Form1 : Form
    {
        private readonly WorkStatus _status = new WorkStatus();
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            var t = new Timer();
            t.Interval = 1000;
            t.Tick += (s, ea) => { _status.Done = true; t.Enabled = false; };
            t.Enabled = true;
            checkBox_WorkDone.DataBindings.Add("Visible", _status, "Done", true, DataSourceUpdateMode.OnPropertyChanged);
            base.OnLoad(e);
        }
    }
