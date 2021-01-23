    for (int i = 0; i < listBoxContacts.Items.Count; i++)
    {
        if (((string)listBoxContacts.Items[i]).Contains(e.UserName))
        {
            string _user = (string)listBoxContacts.Items[i];
            listBoxContacts.Items[i] =  e.UserName + " " + available;
            break;
        }
                
    }
