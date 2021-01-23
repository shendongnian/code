    private void pbx_Click(object sender, EventArgs e)
    { 
 
        Panel p = sender as Panel;
        if(p != null)
        { 
           //TODO add error handling to ensure Tag contains an int
           //...
           DlgSearchDetails newDlg = new DlgSearchDetails((int)p.Tag);
           newDlg.ShowDialog();
        }
    }
