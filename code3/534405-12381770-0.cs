    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GET THE OLD VALUES
            myOldValues.Clear();
            GridView gv = (GridView)sender;
            gv.EditIndex = e.NewEditIndex;
            gv.DataBind();
            //populate 
            for (int i = 0; i < Gridview1.Columns.Count; i++)
            {
                DataControlFieldCell cell = gv.Rows[e.NewEditIndex].Cells[i] as DataControlFieldCell;
                gv.Columns[i].ExtractValuesFromCell(myOldValues, cell, DataControlRowState.Edit, true);
            }
            Session["MyOldValues"] = myOldValues;
        }
