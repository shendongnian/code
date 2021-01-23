    private void ScrollBox()
    {
        foreach (string line in lines)
        {
            scrollbox.LineUp();
            textbox.Text += "/r/n Next Line";
        }
    }
