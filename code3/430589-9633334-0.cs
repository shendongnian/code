    protected void Page_Load(object sender, EventArgs e)
    {
    yourGridView.RowDataBound += (s, ev) =>
            {
               if (ev.Row.RowType == DataControlRowType.DataRow)
               {
                   var btn= (Button) ev.Row.FindControl("btnCheque");
                   btn.OnClientClick = "javascript:SearchReqsult(" + 
                                     DataBinder.Eval(ev.Row.DataItem, 'Id') + ");";
               }
            };
    }
