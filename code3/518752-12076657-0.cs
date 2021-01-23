    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
    public partial class Form1 : Form
    {
        BindingList<Customer> customers = new BindingList<Customer>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; ++i)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    Name = "Name" + i,
                    SurName = "Surname" + i
                });
            }
            dataGridView1.DataSource = customers;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            customers.Add(new Customer
            {
                Id = 22,
                Name = "Newname",
                SurName = "Newsurname"
            });
        }
    }
