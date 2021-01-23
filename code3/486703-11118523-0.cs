    public partial class Form1 : Form
    {
        public Form1()
        {
            var list = new List<Books>
                           {
                               new Books() {Title = "Harry Potter", TotalRating = 5},
                               new Books() {Title = "C#", TotalRating = 5}
                           };
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = list;
            dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(OnRowHeaderMouseClick);
        }
    
        void OnRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Clicked RowHeader!");
        }
    }
