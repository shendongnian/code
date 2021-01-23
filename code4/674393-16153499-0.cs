    DataTable dt;
    DataSet ds = new DataSet();
    private void InitDataTable()
    {
        dt = new DataTable("Gjester");  <<=== this **BEFORE** the if!
        if (!File.Exists("gjesteInfo.xml"))
        {
           ....... 
        }
        else
        {
           // now, in this case, "dt" has been created, and **NOW** you can operate on it!
           dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
           ds.Merge(dt); 
           ds.WriteXml("gjesteInfo.xml");
        }
