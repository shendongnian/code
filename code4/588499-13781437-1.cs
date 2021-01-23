    protected void getChild_Click(object sender, EventArgs e)
    {
        JeansEntities db = new JeansEntities();
        Employe employe = db.Employes.Include("Addresses")
           .SingleOrDefault(p => p.Id == 3);
        var address = employe.Addresses.FirstOrDefault();
        if (address != null)
            uxCountry.Text = address.Country;
    }
