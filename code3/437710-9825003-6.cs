    @Model Site.Models.modeldata;
    
    @foreach (System.Data.DataTable table in Model.DataSets["sampleData"].Tables)
    {
        foreach (System.Data.DataRow row in table.Rows)
        {
            @:row["id"] + " " + row["name"];
        }
    } 
