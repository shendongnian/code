    protected void ldsIncidents_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id;
            e.Result = db.Incidents.Where(i => i.Incident_Number == Int32.TryParse(Request.QueryString["id"], out id) ? id : 0);
        }
    }
