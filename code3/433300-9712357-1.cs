    void ComboBox_OnDropDownClosed(object sender, System.EventArgs e)
    {
        FrameworkElement visualElement = (FrameworkElement)sender;
        while( visualElement != null && !(visualElement is DataCell) )
            visualElement = (FrameworkElement)visualElement.TemplatedParent;
        if( visualElement is DataCell )
        {
            DataCell dataCell = (DataCell)visualElement;
            dataCell.EndEdit();
            if( !(dataCell.ParentRow is InsertionRow) ) dataCell.ParentRow.EndEdit();
        }
    }
