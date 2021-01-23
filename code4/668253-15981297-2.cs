    public partial class frmSelectProgram : Form
    {
        private IEnumerable<string> _programList;
        public frmSelectProgram(IEnumerable<string> programList)
        {
            InitializeComponent();
            _programList = programList;
        }
        private void frmSelectProgram_Load(object sender, EventArgs e)
        {
            foreach (string pro in _programList)
            {
               // MessageBox.Show(pro);
               // for example fill a list box
            }
        }
    }
