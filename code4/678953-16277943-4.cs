    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        Label lbl = (Label)e.Row.FindControl("declaredValue");
        string valueAssignedToLabel = DataBinder.Eval(e.Row.DataItem, "declaredValueColumnOfDataTable").ToString();
        if (valueAssignedToLabel  != "")
        {
            //Here Text value equals "" always!
            string value = lbl.Text;
        }
    }
