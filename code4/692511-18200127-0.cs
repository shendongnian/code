    async void Window_Closing(object sender, CancelEventArgs args)
    {
        var w = (Window)sender;
        var h = (ObjectViewModelHost)w.Content;
        var v = h.ViewModel;
        if (v != null &&
            v.IsDirty)
        {
            args.Cancel = true;
            w.IsEnabled = false;
            // caller returns and window stays open
            await Task.Yield();
            var c = await interaction.ConfirmAsync(
                "Close",
                "You have unsaved changes in this window. If you exit they will be discarded.",
                w);
            if (c)
                w.Close();
            // doesn't matter if it's closed
            w.IsEnabled = true;
        }
    }
