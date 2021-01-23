      protected void Button1_Click(object sender, EventArgs e)
      {
        GridView gvTemp = new GridView();//your grid view
        foreach (GridViewRow gvRow in gvTemp.Rows)
        {
          Repeater repeater = (Repeater)gvRow.FindControl("yourRepeater");
          foreach (RepeaterItem repItem in repeater.Items)
          {
            CheckBox chk = (CheckBox)repItem.FindControl("yourCheckBox");
            if (chk.Checked)
            { 
              //do something here;
            }
          }
        }
      }
