    private void GetData(bool loadArtikli = true)
    {
        // you could wrap this in a using statement, though that isn't necessary
        using (var dbc = new dbEntities())
        {
            if (loadArtikli)
            {
                art = from a in dbc.ARTIKLIs
                    select a;
            }
            
            grp = from g in dbc.ART_GRUPE
                select g;
            
            artikliBindingSource.DataSource = art.ToList();
            artGrupeBindingSource.DataSource = grp.ToList();
        }
    }
    private void refresh_Click(object sender, EventArgs e)
    {
        GetData(false);
    }
    public static void UpdateARTIKLI(ARTIKLI item)
    {
      using (var dbc = new dbEntities())
      {
        if (item.Id > 0)
        { // update existing ones
          var dbitem = context.ARTIKLI 
            .Find(item.Id);
    
          context.Entry(dbItem)
            .CurrentValues
            .SetValues(item);
        }
        else
        { // deal with new ones
          context.ARTIKLI.Add(item);
        }
    
        context.SaveChanges();
      }
    }
