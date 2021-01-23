    if (e.Row.RowType == DataControlRowType.DataRow)
     {
            //DataBinder.Eval(e.Row.DataItem,"Column to check"))
            // based on that you can set the value
            e.Row.BackColor = Drawing.Color.Yellow
     }
