    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckBoxList1.SelectedIndex != -1)
        {
            TextBoxTest.Text = CheckBoxList1.SelectedItem.Value;
        }
           
    }
