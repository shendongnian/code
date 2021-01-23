    //var is of MessageBoxResult type
    var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
    // If the no button was pressed ... 
    if (result == DialogResult.No)
    {
        ...
    }
