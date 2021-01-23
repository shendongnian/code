    public class MailItems
    {
        public string name { get; set; }
        public string address { get; set; }
    }
    
    List<MailItems> items = new List<MailItems>();
    public Form1()
    {
        InitializeComponent();
        items.Add(new MailItems(){address = "1 Some St",name = "Kiklion"});
    }
              
    private void button1_Click(object sender, EventArgs e)
    {
        datagridResults.AutoGenerateColumns = true;
        BindingList<MailItems> gridItems = new BindingList<MailItems>(items);
        dataGridView1.DataSource = gridItems;
    }
