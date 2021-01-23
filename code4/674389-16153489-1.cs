    if(!File.Exists("gjesteInfo.xml"))
    {
         // The file doesn't exist, create the table to receive initial data here
         dt = new DataTable("Gjester");
         DataColumn dc1 = new DataColumn("Fullt navn");
         DataColumn dc2 = new DataColumn("Start dato");
         DataColumn dc3 = new DataColumn("Antall dager");
         dt.Columns.Add(dc1);
         dt.Columns.Add(dc2);
         dt.Columns.Add(dc3);
         dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
         ds.Tables.Add(dt);
    }
    else
    {
        // The file exist, read the data and use the first table to add new info
        ds.ReadXml("gjesteInfo.xml");
        dt = ds.Tables[0];
        dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
    }
    ds.Merge(dt);
    ds.WriteXml("gjesteInfo.xml");
