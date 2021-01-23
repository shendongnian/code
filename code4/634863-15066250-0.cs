        myGrid.RowDataBound += new GridViewRowEventHandler(myGrid_RowDataBound);
        void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    //Raised after each row is databound
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string value = e.Row.Cells[5].Text; //sixth column
                        if (value == "1")
                        {
                            //change button color
