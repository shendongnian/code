    DataTable table = new DataTable("Superheroes"); // name is required
    table.Columns.Add("Name");
    table.Columns.Add("Alias");
    table.Rows.Add("Batman", "Dark Knight");
    table.Rows.Add("Superman", "Man Of Steel");
    table.Rows.Add("Spiderman", null);
    var doc = table.ToXml();
