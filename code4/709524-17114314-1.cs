    List<ListItem> toBeRemoved = new List<ListItem>();
    for(int i=0; i<UPCList.Items.Count; i++){
        if(UPCList.Items[i].Selected == true)
            toBeRemoved.Add(UPCList.Items[i]);
    }
    
    for(int i=0; i<toBeRemoved.Count; i++){
        UPCList.Items.Remove(toBeRemoved[i]);
    }
