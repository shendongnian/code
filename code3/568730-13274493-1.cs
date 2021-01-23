    private void ObjectListView_CellEditStarting(object sender,
                                                 CellEditEventArgs e)
    {
        if (e.Column == SomeCol)
        {
            ISomeInterface M = (e.RowObject as ObjectListView1Row).SomeObject; 
            SetUpCombo(e, 
                       ISomeOtherObjectCollection,"propertyName",
                       M, "ISomeOtherObject",
                       (sender2, e2) =>
                           M.ISomeOtherObject = 
                               (ISomeOtherObject)((ComboBox)sender2).SelectedValue);
        }
        else if (e.Column == SomeOtherCol)  
        {
            ISomeInterface2 M = (e.RowObject as ObjectListView1Row).SomeObject2; 
            SetUpCombo(e, 
                       ISomeOtherObjectCollection2,"propertyName2",
                       M, "ISomeOtherObject2",
                       (sender2, e2) =>
                           M.ISomeOtherObject2 = 
                               (ISomeOtherObject)((ComboBox)sender2).SelectedValue);
        }
