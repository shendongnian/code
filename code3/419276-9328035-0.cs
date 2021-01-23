    foreach (ListItem item in this.CheckBoxList1.Items)
    {
       if (item.Selected)
           {
              Label label = new Label();
              label.Text = item.Value;
              TextBox txt1 = new TextBox();
              form1.Controls.Add(label);
              form1.Controls.Add(txt1);
           }
    }
