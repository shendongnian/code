    DataTable newdatatable = new DataTable("New");
    newdatatable.Columns.Add("Employee Id");
    newdatatable.Columns.Add("Employee Name");
    newdatatable.Columns.Add("Casual Leave");
    newdatatable.Columns.Add("Medical Leave");    
    newdatatable.Columns.Add("Annual Leave");
    newdatatable.AcceptChanges();
    DataSet5TableAdapters.sp_getallempleaveTableAdapter TA = new    DataSet5TableAdapters.sp_getallempleaveTableAdapter();    
    DataSet5.sp_getallempleaveDataTable DS = TA.GetData();
    if (DS.Rows.Count > 0)
    {
          DataView datavw = new DataView();
          datavw = DS.DefaultView;
          datavw.RowFilter = "fldempid='" + txtempid.Text + "' and fldempname='" + txtempname.Text + "'";
          if (datavw.Count > 0)
          {
              string leavehistory = Convert.ToString(datavw[0]["fldleavehistory"]);
                string[] textarray = leavehistory.Split('-');DataRow drow = newdatatable.NewRow();
                        drow[0]=txtempid.Text;
                        drow[1]=txtempname.Text;
                foreach (string samtext in textarray)
                {
                    if (samtext.StartsWith(leavehistory))// I want to check the string with array value
                    {                        
                        drow[samtext.Split(':')[0]]=samtext.Split(':')[1];
                    }
                }
                newdatatable.Rows.Add(drow);
                newdatatable.AcceptChanges();
            }
    }
    gridview1.DataSource=newdatatable;
