    private bool internallyUpdating = false;
    private void CheckboxClick(object sender, EventArgs e)
    {
        if ( !internallyUpdating )
        {
            // Prevent subsequent changes
            internallyUpdating = true;
  
            // Exchange 'checked' state
            if ( sender == checkEdit1 )
            {
                checkEdit2.Checked = !checkEdit2.Checked;
            } 
            else // if (sender == checkEdit2)
            {
                checkEdit1.Checked = !checkEdit1.Checked;
            }
            // other logic here..
            // restore 'on change' functionality.
            internallyUpdating = false;
        }
