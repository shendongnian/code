       protected void Button1_Click(object sender, EventArgs e)
       {
           String input=DropDownList1.SelectedIndex >= 0 ? DropDownList1.SelectedItem.ToString() : "";
           lable1.Text=input;
       }
