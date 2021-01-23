    public partial class Form1 : Form
    {
        private IBindingList blist;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Binding
            this.blist = new BindingList<Product>();
            this.dataGridView1.DataSource = this.blist;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Add
            this.blist.Add(new Product { Id = 2, Text = "Prodotto 2" });
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
