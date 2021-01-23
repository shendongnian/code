    void btnSave_Click(object sender, EventArgs e)
    {
        BindingContext[cv].EndCurrentEdit(); // Commits all values to the underlying data source
        Repository.SaveConfigValues(cv);
    }
