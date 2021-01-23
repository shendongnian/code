     protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (IsFillCombo)
            {
                //fill your list here.
                for (int i = 0; i < datasourcetable.Columns.Count; i++)
                {
                    lst.Add(e.Row.Cells[i].Text);
                }
                IsFillCombo = false;
            }
        }
    } 
