    class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
        private string _itemId;
        public String ItemID
        {
            get { return _itemId; }
            set { _itemId = value; NotifyPropertyChanged("ItemID"); }
        }
        private string _itemName;
        public String ItemName
        {
            get { return _itemName; }
            set { _itemName = value; NotifyPropertyChanged("ItemName"); }
        }
        private double _discountValue;
        public Double DiscountValue
        {
            get { return _discountValue; }
            set { _discountValue = value; NotifyPropertyChanged("DiscountValue"); }
        }
        private double _price;
        public Double Price
        {
            get { return _price; }
            set { _price = value; NotifyPropertyChanged("Price"); }
        }
    }
    public partial class Form1 : Form
    {
        BindingList<Item> OurItems = new BindingList<Item>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateItems();
            BindComboBox();
        }
        private void BindComboBox()
        {
            cboItems.DataSource = OurItems;
            cboItems.DisplayMember = "ItemID";
            cboItems.ValueMember = "ItemID";
        }
        private void PopulateItems()
        {
            StreamReader sr = new StreamReader(@"New Text Document (4).txt");
            foreach (string sLine in sr.ReadToEnd().Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries ))
            {
                var oProps = sLine.Split(new char[] {','});
                OurItems.Add(new Item() {ItemID = oProps[0], ItemName = oProps[1], DiscountValue = Double.Parse(oProps[2]), Price = Double.Parse(oProps[3])});
            }
        }
        private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oSelected = (Item)cboItems.SelectedItem;
            tbName.Text = oSelected.ItemName;
            tbDiscount.Text = oSelected.DiscountValue.ToString();
            tbPrice.Text = oSelected.Price.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OurItems[0].Price = OurItems[0].Price + 50;
        }
    }
