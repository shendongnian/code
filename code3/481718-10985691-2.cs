        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs {
            if (e.Row.RowType == DataControlRowType.DataRow)
                ((HtmlInputText)(e.Row.FindControl("Contract")))
                    .Attributes.Add("type", "tel");
        }  
