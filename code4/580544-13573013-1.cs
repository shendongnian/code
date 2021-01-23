    public partial class Summary : Form
    {
        private Database _viewlist = new Database();
        public Summary()
        {
            InitializeComponent();
        }
        private void Summary_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_viewlist.Pickups.ToArray());
        }
    }
    public class Database
    {
        public List<string> Pickups
        {
            get { return new List<string> {"alfa", "beta"}; }
        }
    }
