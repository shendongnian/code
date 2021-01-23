    using (var conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DatabaseDGVexperiments.Properties.Settings.DatabaseDGVexperimentsConnStg"].ConnectionString))
    {
        conn.Open();
        using (var myAdapt = new SqlCeDataAdapter("SELECT * FROM experiment.dbo.helloworld", conn))
        {
            DataSet mySet = new DataSet();
            myAdapt.Fill(mySet, "AvailableValues");
            DataTable myTable = mySet.Tables["AvailableValues"];
            this.uxExperimentDGV.DataSource = myTable;
        }
    }
    
