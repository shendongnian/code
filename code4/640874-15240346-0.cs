        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new System.Data.DataColumn("Select", typeof(byte)));
        dt.Columns.Add(new System.Data.DataColumn("Client", typeof(string)));
        dt.Columns.Add(new System.Data.DataColumn("PrincipleAmt", typeof(double)));
        
       
        foreach (GridViewRow row in grdRepayment.Rows)
        {
            CheckBox Select = (CheckBox)row.FindControl("ChkSelect");
            Label ClientName = (Label)row.FindControl("lblClientName");
            Label Principal = (Label)row.FindControl("lblPricipal");
            
            dr = dt.NewRow();
            dr[0] = Convert.ToByte(Select.Checked);
            dr[1] = ClientName.Text;
            dr[2] = Convert.ToDouble(Principal.Text);
            
            dt.Rows.Add(dr);
        }
        Session["TempTable"] = dt;
    }
