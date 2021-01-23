    private void ItemClicked(object sender, ItemClickEventArgs e)
    {
        var clickedItem = e.ClickedItem as ItemCollection;
        if (clickedItem != null )
        {
           this.Frame.NavigateTo(typeof(ItemViewer), clickedItem);
        }
    }
