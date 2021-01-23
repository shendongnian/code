    int i = 0;
    while (i < lvwMessages.Items.Count - 1)
    {
       if (lvwMessages.Items[i].Tag == lvwMessages.Items[i + 1].Tag)
          lvwMessages.Items[i + 1].Remove();    
       else
          i++;
    }
