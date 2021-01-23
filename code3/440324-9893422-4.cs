    protected void TaskGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var someValue = GridView1.DataKeys[e.RowIndex]["SomeOtherColumn"].ToString();
    }
 
