    private enum MoveDirection { Up = -1, Down = 1 };
    private static void MoveListViewItems(ListView sender, MoveDirection direction)
    {
    int dir = (int)direction;
    int opp = dir * -1;
    bool valid = sender.SelectedItems.Count > 0 &&
                    ((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));
    if (valid)
    {
	Stack aPila = new Stack();
	ListViewItem item = default(ListViewItem);
	foreach ( item in sender.SelectedItems) {
		aPila.Push(item);
	}
	for (int iaux = 1; iaux <= aPila.Count; iaux++) {
        {
	    item  = (ListViewItem)aPila.Pop();
            int index = item.Index + dir;
            sender.Items.RemoveAt(item.Index);
            sender.Items.Insert(index, item);
            sender.Items[index + opp].SubItems[1].Text = (index + opp).ToString();
            item.SubItems[1].Text = (index).ToString();
        }
    }
    }
