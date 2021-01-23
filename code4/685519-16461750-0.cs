    private void OnSQLServerChanged(object sender, EventArgs e)
        {
    DatabaseCmbBox.MouseClick -= DatabaseCmbBox_Click;
            DatabaseCmbBox.MouseClick += DatabaseCmbBox_Click;
        }
