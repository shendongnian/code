    ListViewItem[] itemsToBeMoved = sender.SelectedItems.Cast<ListViewItem>().ToArray<ListViewItem>(); 
    IEnumerable<ListViewItem> itemsToBeMovedEnum;
    if (direction == MoveDirection.Down)
         itemsToBeMovedEnum = itemsToBeMoved.Reverse();
    else
         itemsToBeMovedEnum = itemsToBeMoved;
