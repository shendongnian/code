    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        foreach (var col in RadGrid1.MasterTableView.Columns)
        {
            if (col.UniqueName == "idAgir")
                col.HeaderText = "Numéro";
            if (col.UniqueName == "objet")
                col.HeaderText = "Titre du Ticket";
            if (col.UniqueName == "dateEtatIncident")
                col.HeaderText = "Date dernière intervention";
        }
        RadGrid1.Rebind(); 
    }
