    DataTable dt = new DataTable("testingDt"); // DataTable declared outside
    Protected void Page_load(object sender ,EventArgs e) 
    {
    dtSelectedLinks.Columns.Add("Site A"); //Datatable used inside the method. 
    dtSelectedLinks.Columns.Add("Site B");
    dtSelectedLinks.Columns.Add("Site C");
    }
