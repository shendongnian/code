     if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRowView1 = (DataRowView)e.Row.DataItem;
                if ((e.Row.RowState= DataControlRowState.Edit) > 0)
                {
                  DropDownList YourdropDown = (DropDownList)e.Row.FindControl("YourdropDown") as DropDownList;
                    if (YourdropDown!=null){
                  YourdropDown.SelectedValue = dRowView1["ID"].ToString();
                     }
                }
             }
