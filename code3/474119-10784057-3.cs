        protected void gridViewReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal val;
                if(decimal.TryParse(e.Row.Cells[1].Text, out val))
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                else
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            }
        }
