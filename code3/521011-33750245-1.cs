     protected void reade_values(object sender, EventArgs e)
    {
       int num=5; // your count goes here
        TextBox tb = new TextBox();
            for (int i = 0; i < num; i++)
            {
               tb=(TextBox)panel.FindControl("txt_box_name"+i.ToString());
               string value = tb.Text; //You have the data now
            }
        }
    }
