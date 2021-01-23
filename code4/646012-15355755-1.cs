    ArrayList arrListChkIDs = new ArrayList();
    //Now Get and Check The Code from List View or put the Index Number  at subItems
    string Code = listView.SelectedItems[0].SubItems["Code"].Text;
    if (!arrListChkIDs.Contains(Code))
    {
    }
    else
    {
        MessageBox.Show("Row Already Exist!",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
        return;
    }
         
