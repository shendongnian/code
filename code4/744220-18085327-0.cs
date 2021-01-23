    public void LoadDutchessSubjects(object sender, EventArgs e)
    {
        if (IsPostback)
            return;
        string connectionString = SqlHelperClass.ConnectionString;
        DataTable subjects = new DataTable();
