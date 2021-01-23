        protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                SetColor2(e.Row, drv["A"].ToString(), 2);
                SetColor2(e.Row, drv["B"].ToString(), 3);
                etc...
            }
        }
