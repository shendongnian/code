    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var run = e.OriginalSource as Run;
        if (run != null)
        {
            int position = (sender as TextBlock).Inlines.ToList().IndexOf(run);
        }
    }
