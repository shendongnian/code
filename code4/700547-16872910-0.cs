        private void GetData(bool reload = false)
        {
            art = from a in dbc.ARTIKLIs
                        select a;
            if (reload)
            {
                dbc.Entry<ART_GRUPE>().Reload(); // <----- new line
            }
            grp = from g in dbc.ART_GRUPE
                        select g;
            artikliBindingSource.DataSource = art.ToList();
            artGrupeBindingSource.DataSource = grp.ToList();
        }
        
        private void refresh_Click(object sender, EventArgs e)
        {
            GetData(true);
            // not sure you need this next line now, but you should test
            artGrupeBindingSource.ResetBindings(false); 
        }
