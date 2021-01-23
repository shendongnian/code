    protected void Button_Click(object sender, EventArgs e)
    {
     foreach (GridViewRow itemrow in GridView1.Rows)
     {
       CheckBox cbview = (CheckBox)(itemrow.Cells[0].FindControl("viewdata"));
       if (cbview.Checked)
       {
     
          string value = GetObjectType(itemrow.Cells[2].Controls[1]);
          Response.Write(value);
       }
     }
     
    private String GetObjectType(Control ctrl)
        {
            switch (ctrl.GetType().Name)
            {
                case "Label":
                    return ((Label)ctrl).Text;
                case "TextBox":
                    return ((TextBox)ctrl).Text;
            }
            return "";
        }
