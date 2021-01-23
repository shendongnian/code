    private void CopyButton_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCopy.Checked)
        {
            copy1 = true;
            cut1 = false;
            // ToDo: Uncheck checkbox cut1
        }
        else
        {
            copy1 = false;
        {
    }
    
    private void Cut_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCut.Checked)
        {
            cut1 = true;
            copy1 = false;
            // ToDo: Uncheck checkbox copy1
        }
        else
        {
            cut1 = false;
        {
    }
