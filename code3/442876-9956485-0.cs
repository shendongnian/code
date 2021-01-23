    private void addContentInCmbPhy() 
    {
        List<string> match;
        using (var  myDb = new DbClassesDataContext(dbPath))
    {
       cmbPhysicians.Items.AddRange((from phy in myDb.Physicians
                select phy.Phy_FName).ToArray());
    }
    //  foreach(var phy in match){
    //      cmbPhysicians.Items.Add(phy);
    //  }
    }
