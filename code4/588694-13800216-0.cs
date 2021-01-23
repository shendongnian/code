    // Set licensing info.
    ComponentInfo.SetLicense("FREE-LIMITED-KEY");
    ComponentInfo.FreeLimitReached += (sender, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;
    
    // Create mail merge data source. 
    // You should use DataGridView.DataSource property - it will return DataView or DataTable that is data-bound to your DataGridView.
    var dataTable = new DataTable()
    {
    	Columns =
    	{
    		new DataColumn("Name"),
    		new DataColumn("Surname"),
    		new DataColumn("Company")
    	},
    	Rows =
    	{
    		{ "John", "Doe", "ACME" },
    		{ "Fred", "Nurk", "ACME" },
    		{ "Hans", "Meier", "ACME" }
    	}
    };
    
    var document = DocumentModel.Load("LabelTemplate.docx", LoadOptions.DocxDefault);
    
    // Use this if field names and data column names differ. If they are the same (case-insensitive), then you don't need to define mappings explicitly.
    document.MailMerge.FieldMappings.Add("First_Name", "Name");
    document.MailMerge.FieldMappings.Add("Last_Name", "Surname");
    document.MailMerge.FieldMappings.Add("Company_Name", "Company");
    
    // Execute mail merge. Each mail merge field will be replaced with the data from the data source's appropriate row and column.
    document.MailMerge.Execute(dataTable);
    
    // Remove any left mail merge field.
    document.MailMerge.RemoveMergeFields();
    
    // Save resulting document to a file.
    document.Save("Labels.docx");
