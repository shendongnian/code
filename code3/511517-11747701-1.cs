    IInputElement item = myListView.Items[itemIndex] as IInputElement;
    if (item != null)
    {
        // Uncomment the line below if you want to scroll to the item's position.
        // myListView.ScrollIntoView(item);
        // Set focus on the item.
        Keyboard.Focus(item); 
    }
