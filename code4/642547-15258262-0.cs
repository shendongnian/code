    protected void btnAdd_Click(object sender, EventArgs e)
                {
                    Wine w2 = new Wine();
                    w2.Title = txtTitle.Text;
                    w2.Year = txtYear.Text;
                    ent2.Wines.AddObject(w2);
                    ent2.SaveChanges();
                    **RefreshGrid**
    
                }
