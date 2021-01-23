      protected void Button1_Click(object sender, EventArgs e)
      {
        foreach (GridViewRow gvRow in yourGridView.Rows)
        {
          Repeater repeater = (Repeater)gvRow.FindControl("yourRepeater");
          foreach (RepeaterItem repItem in repeater.Items)
          {
            RadioButtonList rlist = (RadioButtonList)repItem.FindControl("yourRadioButtonList");
            if (rlist.SelectedItem.Value == "0")
            {            
              //code for not selected radio buttons goes here
            }
            else if (rlist.SelectedItem.Value == "1")
            {            
              //code for selected radio buttons goes here
            }
          }
        }
      }
