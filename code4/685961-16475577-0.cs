    private void iSelectAll_ItemClick(object sender,  e)
    {
        Form DtexteditoR = new DtexteditoR();
        //DtexteditoR.Show();
    
        if (DtexteditoR.IsMdiChild)
        {
                rtb.SelectAll();
        }
    
    }
