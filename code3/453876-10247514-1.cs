    protected void SqlDataSourceGridView_Selecting(object sender, SqlDataSourceSelectingEventArgs e) {
        SqlDataSourceGridView.FilterExpression = string.Empty;
        if (CheckBox1.Checked) {
            SqlDataSourceGridView.FilterExpression += "(A=1)";
        }
        if (CheckBox2.Checked) {
            if (!string.IsNullOrEmpty(SqlDataSourceGridView.FilterExpression)) SqlDataSourceGridView.FilterExpression += " OR ";
            SqlDataSourceGridView.FilterExpression += "(B=1)";
        }
        if (CheckBox3.Checked) {
            if (!string.IsNullOrEmpty(SqlDataSourceGridView.FilterExpression)) SqlDataSourceGridView.FilterExpression += " OR ";
            SqlDataSourceGridView.FilterExpression += "(C=1)";
        }
        if (CheckBox4.Checked) {
            if (!string.IsNullOrEmpty(SqlDataSourceGridView.FilterExpression)) SqlDataSourceGridView.FilterExpression += " OR ";
            SqlDataSourceGridView.FilterExpression += "(D=1)";
        }
    }
