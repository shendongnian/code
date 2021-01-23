    for (int i = 0; i < listBoxContacts.Items.Count; i++)
    {
        if (((string)listBoxContacts.Items[i]).Contains(e.UserName))
        {
            listBoxContacts.Items[i] =  e.UserName + " " + available;
            break;
        }
                
    }
