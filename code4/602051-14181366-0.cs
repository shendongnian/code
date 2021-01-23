dataGridView1.Modifiers = Public 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var f = new Form2 { Owner = this})
            {
                f.valueFromSelectedCell = dataGridView1.SelectedCells[0].EditedFormattedValue.ToString();
                f.ShowDialog();
            }
        }
    }
    public partial class Form2 : Form
    {
        public string valueFromSelectedCell { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = valueFromSelectedCell;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = this.Owner as Form1;
            var currentCell = f.dataGridView1.CurrentCell;
            f.dataGridView1[currentCell.ColumnIndex, currentCell.RowIndex].Value = textBox1.Text;
            Close();
        }
    }
