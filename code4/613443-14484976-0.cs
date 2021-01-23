    private async void ChangeItems(object sender, object o)
    {   
        var totalItems = TheFlipView.Items.Count;
        var newItemIndex = (TheFlipView.SelectedIndex + 1) % totalItems;
        await TheFlipView.FadeOut();
        TheFlipView.SelectedIndex = newItemIndex;
        TheFlipView.FadeIn();
    }     
