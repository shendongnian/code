    BindingSource bindingSource1= new BindingSource();
    private void LoadGrid()
    {
        List<Data> dataListing = new List<Data>()
        {
            new Data() { Name = "Jabberwocky", Operation="Read", DateStart= DateTime.Now.AddDays(-2), DateEnd = DateTime.Now.AddDays(-2), Description="Process Started No errors"},
            new Data() { Name = "Space", Operation="Write", DateStart= DateTime.Now.AddDays(-2), DateEnd = DateTime.Now.AddDays(-1), Description="Final process remote allocation of 3000 items to main buffer."},
            new Data() { Name = "Stock Purchase", Operation="DataWarehousing", DateStart= DateTime.Now, DateEnd = DateTime.Now, Description="Shared data transport."}
        };
     
        var items = from dta in dataListing
            select new
            {
               OperationName = dta.Name,
               Start         = dta.DateStart.ToShortDateString(),
               End           = dta.DateEnd.ToShortDateString(),
               Operation     = dta.Operation,
               Description   = dta.Description
             };
     
        bindingSource1.DataSource = items;
        dataGridView1.DataSource  = bindingSource1;
     
        // Grid attributes
        dataGridView1.BorderStyle         = BorderStyle.Fixed3D;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
     
    }
