    string str = string.Empty;
    for(int i=0; i<lstView.Items.Count; i++)
    {
        for(int j=0; j<lstView.Items[i].SubItems.Count; j++)
        {
            str = lstView.Items[i].SubItems[j].Text;
        }
    }
