    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //This is current row. Set it to default color
        EmployeesGridView.SelectedRow.BackColor = System.Drawing.Color.White;
        //This is selected row. Set it to color you wish
        EmployeesGridView.Rows[e.NewSelectedIndex].BackColor = System.Drawing.Color.Black;
    }
