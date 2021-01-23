                DataRow dr = mDataTable.NewRow();
                dr["KEY"] = "DUMMY";
                mDataTable.Rows.Add(dr);
                
                DataView pView = new DataView(mDataTable);
                gridView.DataSource = pView;
                gridView.DataBind();
    
                gridView.Rows[0].CssClass = "Hidden"; //I am not sure about this actually, see the result
