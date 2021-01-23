    void LocalReport_SubreportProcessing(
        object sender,
        Microsoft.Reporting.WebForms.SubreportProcessingEventArgs e)
    {
        // get empID from the parameters
        int iEmpID = Convert.ToInt32(e.Parameters[0].Values[0]);
    
        // remove all previously attached Datasources, since we want to attach a
        // new one
        e.DataSources.Clear();
    
        // Retrieve employeeFamily list based on EmpID
        var employeeFamily = CpReportCustomData.Data.CustomDS.GetAllEmployeeFamily()
                             .FindAll(element => element.ID == iEmpID);
    
        // add retrieved dataset or you can call it list to data source
        e.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
        {
            Name = "DSEmployeeFamily",
            Value = employeeFamily
    
        });
