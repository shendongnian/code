    using System.Data.SqlServerCe;
    .....
    void PopulateGridView() 
    { 
        SqlCeConnection conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DatabaseDGVexperiments.Properties.Settings.DatabaseDGVexperimentsConnStg"].ConnectionString); 
        SqlCeDataAdapter myAdapt = new SqlCeDataAdapter("SELECT refText FROM helloworld", conn); 
        DataSet mySet = new DataSet(); 
        myAdapt.Fill(mySet, "AvailableValues"); 
        DataTable myTable = mySet.Tables["AvailableValues"]; 
        this.uxExperimentDGV.DataSource = myTable; 
    } 
