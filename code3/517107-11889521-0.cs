    private void Form5_Load(object sender, EventArgs e)
    {
        // Creating and configuring the ObjectDataSource component:
        var objectDataSource = new Telerik.Reporting.ObjectDataSource();
        objectDataSource.DataSource = GetAllData(); // GetData returns a DataSet with three tables
        objectDataSource.DataMember = "Product"; /// Indicating the exact table to bind to. If the DataMember is not specified the first data table will be used.
        objectDataSource.CalculatedFields.Add(new Telerik.Reporting.CalculatedField("FullName", typeof(string), "=Fields.Name + ' ' + Fields.ProductNumber")); // Adding a sample calculated field.
    
        // Creating a new report
        Telerik.Reporting.Report report = new Telerik.Reporting.Report();
    
        // Assigning the ObjectDataSource component to the DataSource property of the report.
        report.DataSource = objectDataSource;
    
        // Use the InstanceReportSource to pass the report to the viewer for displaying
        Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();
        reportSource.ReportDocument = report;
    
        // Assigning the report to the report viewer.
        reportViewer1.ReportSource = reportSource;
    
        // Calling the RefreshReport method (only in WinForms applications).
        reportViewer1.RefreshReport();
    }
    
    static DataSet GetAllData()
    {
        const string connectionString =
            "Data Source=(local)\\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True";
    
        string selectCommandText = "SELECT Name, ProductCategoryID FROM Production.ProductCategory;" +
            "SELECT Name, ProductCategoryID FROM Production.ProductSubcategory;" +
            "SELECT Name, ProductNumber FROM Production.Product;";
    
        SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, connectionString);
        DataSet dataSet = new DataSet();
    
        // The data set will be filled with three tables: ProductCategory, ProductSubcategory 
        // and Product as the select command contains three SELECT statements.
        adapter.Fill(dataSet);
    
        // Giving meaningful names for the tables so that we can use them later.
        dataSet.Tables[0].TableName = "ProductCategory";
        dataSet.Tables[1].TableName = "ProductSubcategory";
        dataSet.Tables[2].TableName = "Product";
        return dataSet;
    }
