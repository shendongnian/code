    protected void getChild_Click(object sender, EventArgs e)
    {
        JeansEntities db = new JeansEntities();
        Employe employe = db.Employes.Include("Address")
           .SingleOrDefault(p => p.Id == 3);
        uxCountry.Text = employe.Address.Country;
    }
