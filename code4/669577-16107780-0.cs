    public class Address
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
    public class ListAddressViewModel
    {
        public IList<Address> AddressList { get; set; }
        public Address SelectedAddress { get; set; }
        public ListAddressViewModel()
        {
            AddressList = new List<Address>();
            init();
        }
        private void init()
        {
            AddressList = new List<Address>
            {
                new Address { AddressLine1 = "Address 1", City = "City 1", PostCode = "PostCode 1" },
                new Address { AddressLine1 = "Address 2", City = "City 2", PostCode = "PostCode 2" },
                new Address { AddressLine1 = "Address 3", City = "City 3", PostCode = "PostCode 3" },
                new Address { AddressLine1 = "Address 4", City = "City 4", PostCode = "PostCode 4" },
                new Address { AddressLine1 = "Address 5", City = "City 5", PostCode = "PostCode 5" },
                new Address { AddressLine1 = "Address 6", City = "City 6", PostCode = "PostCode 6" },
                new Address { AddressLine1 = "Address 7", City = "City 7", PostCode = "PostCode 7" },
                new Address { AddressLine1 = "Address 8", City = "City 8", PostCode = "PostCode 8" },
                new Address { AddressLine1 = "Address 9", City = "City 9", PostCode = "PostCode 9" },
                new Address { AddressLine1 = "Address 10", City = "City 10", PostCode = "PostCode 10" },
                new Address { AddressLine1 = "Address 11", City = "City 11", PostCode = "PostCode 11" },
                new Address { AddressLine1 = "Address 12", City = "City 12", PostCode = "PostCode 12" },
                new Address { AddressLine1 = "Address 13", City = "City 13", PostCode = "PostCode 13" },
                new Address { AddressLine1 = "Address 14", City = "City 14", PostCode = "PostCode 14" },
                new Address { AddressLine1 = "Address 15", City = "City 15", PostCode = "PostCode 15" },
                new Address { AddressLine1 = "Address 16", City = "City 16", PostCode = "PostCode 16" },
                new Address { AddressLine1 = "Address 17", City = "City 17", PostCode = "PostCode 17" },
                new Address { AddressLine1 = "Address 18", City = "City 18", PostCode = "PostCode 18" },
                new Address { AddressLine1 = "Address 19", City = "City 19", PostCode = "PostCode 19" }
            };
        }
    }
    public partial class Form3 : Form
    {
        private System.Windows.Forms.BindingSource bindingSource1;
        private ListAddressViewModel VM { get; set; }
        private DataGridView dataGridView1;
        public Form3()
        {
            InitializeComponent();
            this.dataGridView1 = new DataGridView();
            this.VM = new ListAddressViewModel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            //this.bindingSource1.DataSource = typeof(ListAddressViewModel);
            this.bindingSource1.DataSource = this.VM;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //    this.AddressLine1,
            //    this.City,
            //    this.PostCode});
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.bindingSource1, "AddressList", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Location = new System.Drawing.Point(33, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            //this.dataGridView1.Size = new System.Drawing.Size(1014, 421);
            this.dataGridView1.Size = new System.Drawing.Size(345, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.Controls.Add(this.dataGridView1);
        }
        //Selection Change Handler
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var addr = (Address)dataGridView1.SelectedRows[0].DataBoundItem;
                var msg = String.Format("{0}, {1}, {2}", addr.AddressLine1, addr.City, addr.PostCode);
                MessageBox.Show(msg, "Message", MessageBoxButtons.OK);
            //    _vm.SelectedAddress = (Address)dataGridView1.SelectedRows[0].DataBoundItem;
            }
        }
    }
