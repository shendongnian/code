    private void GetData()
    {
        // you could wrap this in a using statement, though that isn't necessary
        using (var dbc = new dbEntities())
        {
            art = from a in dbc.ARTIKLIs
                select a;
            
            grp = from g in dbc.ART_GRUPE
                select g;
            
            artikliBindingSource.DataSource = art.ToList();
            artGrupeBindingSource.DataSource = grp.ToList();
        }
    }
    private void refresh_Click(object sender, EventArgs e)
    {
        GetData();
        // not sure you need this next line now, but you should test
        artGrupeBindingSource.ResetBindings(false); 
    }
