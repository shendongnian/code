     if (!IsPostBack)
     {
         empd = new Employee_DetailsDataContext();
         empd.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DemosConnectionString1"].ConnectionString;
         display_emp();
     }
