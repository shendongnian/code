    dataGridView1.EditingControlShowing += new 
        DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox control = e.Control as ComboBox;
        if (control != null)
        {            
            control.DropDown += new EventHandler(control_DropDown);
            control.DropDownClosed += new EventHandler(control_DropDownClosed);
        }
    }
