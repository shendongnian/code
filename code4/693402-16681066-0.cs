            DataTable dt = new DataTable();
            dt.Columns.Add("EmpID");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("UnitID");
            dt.Columns.Add("UnitName");
            DataRow dr = dt.NewRow();
            dr["EmpID"] = 1;
            dr["EmpName"] = "Jack";
            dr["UnitID"] = 4;
            dr["UnitName"] = "MyUnit";
            dt.Rows.Add(dr);
    
            GridView1.DataSource = dt;
            GridView1.DataBind();
    
            //GridView1.Columns[0].Visible = false; // will error on autogenerate columns
            // So after your data is bound, loop though
    
            int columnIndexEmpID = 0;
            int columnIndexUnitID = 2;
    
            GridView1.HeaderRow.Cells[columnIndexEmpID].Visible = false;
            GridView1.HeaderRow.Cells[columnIndexUnitID].Visible = false;
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                gvr.Cells[columnIndexEmpID].Visible = false;
                gvr.Cells[columnIndexUnitID].Visible = false;
            }
