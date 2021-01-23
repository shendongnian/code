    int offset = 0;
    case Keys.Up:
        offset = -1; 
        break;
    case Keys.Down:
        offset = 1;
        break;
    if (listView.SelectedItems.Count > 0) 
    {
        int newSpot = 0;
        int index = 0;
        if (listOrderNames.IndexOf(listView.SelectedItems[0].Text) == 0) 
        {
            reorder(0, true);
            newSpot = listOrderNames.Count + offset;
        }
        else 
        {
            newSpot = listOrderNames.IndexOf(listView.SelectedItems[0].Text) + offset;
            index = listOrderNames.IndexOf(listView.SelectedItems[0].Text) + offset;
            swap(listOrderNames.IndexOf(listView.SelectedItems[0].Text), newSpot);
        }
        for (int i = 0; i < listView.Items.Count; i++) 
        {
            listView.Items[i].Selected = false;
        }
        listView.Items[newSpot].Selected = true;
    }
