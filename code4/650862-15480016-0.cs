    protected void DocumentList_Click(object sender, BulletedListEventArgs e)
    {
         ListItem li = DocumentList.Items[e.Index];
         Sting filepath = li.Value;
         Sting filename = li.Text;
    
    }
