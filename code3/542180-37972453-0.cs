    List<EmployeeData> query = data.Where(x => x.Field<string>("First_Name") != string.Empty).Select(x =>
    
        new EmployeeData
            {
            empID = x.Field<double>("EMPLOYEE"),
            firstName = x.Field<string>("First_Name"),
            lastName = x.Field<string>("Last_Name"),
            JobCategory = x.Field<string>("Job Title"),
            StartDate = x.Field<Nullable<DateTime>>("Hire Dt"),
            EndDate =   x.Field<Nullable<DateTime>>("Term Dt"),
            TermReason = x.Field<string>("Term Reason"),
            PeggedUID = x.Field<Nullable<double>>("Pegged UserID"),
            UpdateDate = x.Field<Nullable<DateTime>>("Last Updated")
            }).ToList();
        
        IExportEngine engine = new ExcelExportEngine();
        engine.AddData(EmployeeData);
        MemoryStream memory = engine.Export();
