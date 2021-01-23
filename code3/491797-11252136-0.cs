    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ItemList list = new ItemList();
            list.listItems.Add(new Item() { name = "Sample" });
            list.listItems.Add(new Item() { name = "Sample" });
            list.listItems.Add(new Item() { name = "Sample" });
            list.listItems.Add(new Item() { name = "Sample" });
            list.listItems.Add(new Item() { name = "Sample" });
            list.listItems.Add(new Item() { name = "Sample" });
            dataGridView1.DataSource = list.listItems;
        }
    }
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name_;
        public string name
        {
            get { return name_; }
            set
            {
                name_ = value;
                this.NotifyPropertyChanged("name");
            }
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
    public class ItemList
    {
        public BindingList<Item> listItems { get; set; }
        // Default constructor 
        public ItemList()
        {
            listItems = new BindingList<Item>();
        }
        public BindingList<Item> returnList()
        {
            return listItems;
        }
        public void addItem(Item newItem)
        {
            listItems.Add(newItem);
        }
    } 
