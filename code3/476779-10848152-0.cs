    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected == true)
                {
                    //Response.Write(item.Value);
                    LabelTest.Text = item.Value;
                }
            } 
    }
