    if(File.Exists("gjesteInfo.xml"))
       File.Delete("gjesteInfo.xml")
    
    dt = new DataTable("Gjester");
    DataColumn dc1 = new DataColumn("Fullt navn");
    DataColumn dc2 = new DataColumn("Start dato");
    DataColumn dc3 = new DataColumn("Antall dager");
    dt.Columns.Add(dc1);
    dt.Columns.Add(dc2);
    dt.Columns.Add(dc3);
    dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
    ds.Tables.Add(dt);
    ds.Merge(dt);
    ds.WriteXml("gjesteInfo.xml");
