    public partial class Form1 : Form
    {
        List<LedgerEntry> ledgerEntries = new List<LedgerEntry>();
        List<Address> addresses = new List<Address>();
        BindingSource entrySource = new BindingSource();
        BindingSource adSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            entrySource.DataSource = ledgerEntries;
            adSource.DataSource = addresses;
            DataGridViewComboBoxColumn adr = new DataGridViewComboBoxColumn();
            adr.DataPropertyName = "Address";
            adr.DataSource = adSource;
            adr.DisplayMember = "OrganizationName";
            adr.HeaderText = "Organization";
            adr.ValueMember = "Ref";
            ledger.Columns.Add(adr);
            ledger.DataSource = entrySource;
            addresses.Add(new Address("Test1", "1234", 5678));
            addresses.Add(new Address("Test2", "2345", 9876));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (LedgerEntry le in ledgerEntries)
                MessageBox.Show(le.Address.OrganizationName + " // " + le.Description);
        }
    }
    public class LedgerEntry
    {
        public string Description { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string OrganizationName { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public Address(string orgname, string addr, int zip)
        {
            OrganizationName = orgname;
            StreetAddress = addr;
            ZipCode = zip;
        }
        public Address Ref
        {
            get { return this; }
            set { Ref = value; }
        }
        public override string ToString()
        {
            return this.OrganizationName;
        }
    }
