    protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    row.Attributes["onclick"] =ClientScript.GetPostBackClientHyperlink(GridView1,
                "Select$" + row.DataItemIndex, true);
                }
            }
            base.Render(writer); 
        }
