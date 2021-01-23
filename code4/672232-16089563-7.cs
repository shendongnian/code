    private void InitDataTable()
    {
        dt = new DataTable();
        DataSet ds = new DataSet();
        ds.ReadXml("gjesteInfo.xml");
        DataTableCollection tables = ds.Tables;
        if (0 == tables.Count){
            DataColumn dc1 = new DataColumn("Fullt navn");
            DataColumn dc2 = new DataColumn("Start dato");
            DataColumn dc3 = new DataColumn("Antall dager");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
        }
        else 
        {
            dt = tables[0];
        }
    }
    private void lagre_Click(object sender, EventArgs e)
    {
        InitDataTable();
        dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
        gjesterutenrom.Items.Add(gjestenavnInput.Text);
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        ds.WriteXml("gjesteInfo.xml");
        gjestenavnInput.Text = "";
        datoInnsjekk.Text = "";
        antallDager.Text = "";
    }
