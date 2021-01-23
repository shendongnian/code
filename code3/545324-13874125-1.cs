    public partial class Form1 : Form
    {
        DataGridViewCheckBoxColumn Column;
        CheckBox checkbox;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            List<Customer> CustomerList = new List<Customer>();
            for (int i = 0; i <= 4; i++)
            {
                Customer cust = new Customer();
                cust.id = i;                 
                cust.FirstName = "john" + i.ToString();
                cust.LastName = "deo" + i.ToString();
                cust.Age = 20 + i;
                CustomerList.Add(cust);
            }
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = CustomerList;            
        }
    }
    public class Customer:Person
    {
        public int id { get; set; }       
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
