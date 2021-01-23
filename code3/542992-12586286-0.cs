    public partial class Form1 : Form
    {
        HashSet<Order> list = new HashSet<Order>();
        public Form1()
        {
            InitializeComponent();
            LoadData();
            comboBox1.DisplayMember = "OrderName";
            comboBox1.ValueMember = "OrderNum";
            comboBox1.DataSource = list.ToArray<Order>();
        }
        private void LoadData()
        {
            // Load some sample data
            for(int x = 0; x < 10; x++)
            {
                Order o = new Order(){OrderName = "Name" + x, OrderNum = x};
                list.Add(o);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Select the item with order number = 4 
            var x = list.Where<Order>(o => o.OrderNum == 4).FirstOrDefault<Order>();
            comboBox1.SelectedItem = x;
            
        }
    }
    public class Order
    {
        public string OrderName;
        public int OrderNum;
        public override string ToString()
        {
            return this.OrderName;
        }
    }
