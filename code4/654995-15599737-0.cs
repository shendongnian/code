    List<ListItem> toBeRemoved = new List<ListItem>();
    for(int i=0; i<chkItems.Items.Count; i++){
        if(chkItems.Items[i].Selected == true)
            toBeRemoved.Add(chkItems.Items[i]);
    }
    
    for(int i=0; i<toBeRemoved.Count; i++){
        chkItems.Items.Remove(toBeRemoved[i]);
    }
