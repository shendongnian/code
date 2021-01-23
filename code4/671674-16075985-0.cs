         for (int i = 0; i < dv_count; i++)
            {
             TextBox txt_box = new TextBox();
             txt_box.Text = "";
             txt_box.ID = "s" + i;
            placeholder1.Controls.Add(txt_box);
    }
    
  
    TextBox lbl_type = (TextBox)placeholder1.FindControl("s" + i);
