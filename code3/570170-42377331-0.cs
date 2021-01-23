    public void RefreshDataGrid(){
        using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[
            "RecipeManager.Properties.Settings.RecipeManagerConnectionString"].ConnectionString)){
           var fetchedData = conn.Query<Flavour>("select * from [Flavour]");
            ConvertToDataTable(fetchedData);
        }
    }
