        protected void ldsIncidents_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id;
                // now you can check the values you gat;
                var queryString = Request.QueryString["id"];
                int iNr =Int32.TryParse(queryString, out id) ? id : 0;
                e.Result = db.Incidents.Where(i => i.Incident_Number == iNr);
            }
        }
