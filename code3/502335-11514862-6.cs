    public partial class progHider : Form
    {
        ProcessListGenerator _processes;
        public progHider()
        {
            InitializeComponent();
        }
        private void progHider_Load(object sender, EventArgs e)
        {
            _processes = new ProcessListGenerator();
            _processes.UpdateProcessList();
            listBox1.DataSource = _processes.ProcessList;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _processes.UpdateProcessList();
        }
    }
