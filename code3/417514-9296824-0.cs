    public Form1()
    {
        InitializeComponent();
    
        DataTable dt = new DataTable("Customers");
        DataColumn dc;
    
        dc = new DataColumn();
        dc.DataType = typeof(int);
        dc.ColumnName = "CustomerID";
    
        dt.Columns.Add(dc);
        dt.Columns.Add(new DataColumn("LastName"));
        dt.Columns.Add(new DataColumn("FirstName"));
        // Concatenation of first and last names 
        dt.Columns.Add(new DataColumn("FullName"));
        dt.Columns.Add(new DataColumn("Address"));
        dt.Columns.Add(new DataColumn("City"));
        dt.Columns.Add(new DataColumn("State"));
        dt.Columns.Add(new DataColumn("Zip"));
        dt.Columns.Add(new DataColumn("Phone"));
    
        dc = new DataColumn();
        dc.DataType = typeof(DateTime);
        dc.ColumnName = "LastPurchaseDate";
        dt.Columns.Add(dc);
    
        dc = new DataColumn();
        dc.DataType = typeof(int);
        dc.ColumnName = "CustomerType";
        dt.Columns.Add(dc);
    
        // Populate the table 
        dt.Rows.Add(2, "Baggins", "Bilbo", "Baggins, Bilbo", "Bagshot Row #1", "Hobbiton", "SH", "00001", "555-2222", DateTime.Parse("24/9/2008"), 1);
        dt.Rows.Add(1, "Baggins", "Frodo", "Baggins, Frodo", "Bagshot Row #2", "Hobbiton", "SH", "00001", "555-1111", DateTime.Parse("14/9/2008"), 1);
        dt.Rows.Add(6, "Bolger", "Fatty", "Bolger, Fatty", "ProudFeet Creek", "Hobbiton", "SH", "00001", "555-1111", DateTime.Parse("14/9/2008"), 1); 
        dt.Rows.Add(4, "Elessar", "Aragorn", "Elessar, Aragorn", "Citadel", "Minas Tirith", "Gondor", "00000", "555-0000", DateTime.Parse("14/9/2008"), 4);
        dt.Rows.Add(5, "Evenstar", "Arwin", "Evenstar, Arwin", "Citadel", "Minas Tirith", "Gondor", "00000", "555-0001", DateTime.Parse("23/9/2008"), 4);
        dt.Rows.Add(3, "Greyhame", "Gandalf", "Grayhame, Gandalf", DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 3);
    
        DataGridViewComboBoxColumn cboCategory = new DataGridViewComboBoxColumn();
    
        List<CustomerType> customerTypes = new List<CustomerType> { new CustomerType { Id = 1, Name = "Good" }, new CustomerType { Id = 4, Name = "Bad" }, new CustomerType { Id = 3, Name = "Ugly" } };
    
        cboCategory.HeaderText = "Customer Type";
        cboCategory.DataSource = customerTypes;
        cboCategory.DisplayMember = "Name";
        cboCategory.ValueMember = "Id";
        cboCategory.DataPropertyName = "CustomerType";
    
        dataGridView1.Columns.Add(cboCategory);
         
        dataGridView1.DataSource = dt;
    
    }
