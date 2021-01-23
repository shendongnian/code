    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<MyItem> items = new List<MyItem>();
            for (int i = 0; i < 10; i++)
            {
                items.Add(new MyItem { Key = i, value = Image.FromFile(@"e:\test.jpg") });
            }
            
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Columns.Add("Key", "Key");
            this.dataGridView1.Columns.Add(new DataGridViewImageColumn() { HeaderText="Status"});
            this.dataGridView1.Columns[0].DataPropertyName = "Key";            
            this.dataGridView1.Columns[1].DataPropertyName = "value";
            
            this.dataGridView1.DataSource = items;
            
        }
    }
    public class MyItem
    {
        public int Key { get; set; }
        public Image value { get; set; }
    }
