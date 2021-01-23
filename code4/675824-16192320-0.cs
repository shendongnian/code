    public void AddDevelopperButton_Click(object sender, EventArgs e)
    {
        this.AddDevelopper(txb_name.Text, txb_firtname.Text);
    }
    public void AddDevelopper(string name, string firstName)
    {
        Developper devAdded = new Developper();
        devAdded.Name = name;
        devAdded.FirstName = firstName;
        using(BugTrackerDBContainer db = new BugTrackerDBContainer())
        {
            db.AddToDevelopper(devAdded);
            db.SaveChanges();
        }
    }
