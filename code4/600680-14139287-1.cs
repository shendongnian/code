    DataTable city = new DataTable(); // instantiate here
    for (int i = 0; i < gridview1.Rows.Count; i++)
    {
        string yojnaNo = "";
        CheckBox chl = (CheckBox)gridview1.Rows[i].Cells[0].FindControl("CheckBox1");
        if (chl != null)
        {
            if (chl.Checked == true)
            {
                int rowsNo = (Convert.ToInt16(chl.ToolTip) - 1); //Convert.ToInt16(SrNo);
                yojnaNo = ((Label)gridview1.Rows[rowsNo].FindControl("lblYojnaNo")).Text;
                sc.Add(yojnaNo);
            }
        }
        objyojnadetail4.YojnaNo = sc;
        // this foreach loop may loop on anything the objyojnadetail4.Selectcity() provides
        // what was important is that, in this loop you insert each data into rows in city.
        foreach(var singleItem in objyojnadetail4.Selectcity().Rows)
        {
            city.Rows.Add(singleItem);
        }
    }
