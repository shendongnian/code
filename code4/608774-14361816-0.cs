    private Contact newRecord = null;
    public Add()
    {
        InitializeComponent();
        newRecord = new Contact();
    }
    
    /**** code to add the user-input to the new Contact object ****/
    
    private void btnAddClose_Click(object sender, EventArgs e)
    {
        Master.AddressBook.Add(newRecord);
        this.Close(); 
    }
