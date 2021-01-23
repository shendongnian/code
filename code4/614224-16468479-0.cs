    using System.Windows.Forms;
 ...
    public bool validateForm(TextBox txtTitle, TextBox txtPath, CheckedListBox ckList)
    {
        bool title = false;
        bool path = false;
            
        if (txtTitle.Text == String.Empty)
        {
           title = false;
           txtTitle.Text = "Title is empty!";
           paintred(txtTitle);
        } else { title = true; paintwhite(txtTitle); }
        if (txtPath.Text == String.Empty)
        {
           path = false;
           txtPath.Text = "Path is empty!";
           paintred(txtPath); 
        } else { path = true; paintwhite(txtPath); }   
        bool ckItem1 = ckList.GetItemChecked(0);
        bool ckItem2 = ckList.GetItemChecked(1);
        bool ckItem3 = ckList.GetItemChecked(2);
        bool ckItem4 = ckList.GetItemChecked(3);
        bool ckItem5 = ckList.GetItemChecked(4);
        if (title && path && ckItem1 && ckItem2 
            && ckItem3 && ckItem4 &&
               ckItem5 )
            return true;
        else
            return false;
    }
