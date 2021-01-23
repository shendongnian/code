    bool positionChanged = false;
    private void Source_PositionChanged(object sender, EventArgs e)
    {
        positionChanged = true;
    }
    private void Grid_KeyUp(Object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up)
            previousItem();
        else if (e.KeyCode == Keys.Down)
            nextItem();
        positionChanged = false;
    }
    private void previousItem()
    {
        BindingSource bs = null;
        switch (this.Type)
        {
            case AdminType.Channel:
                bs = channelBindingSource;
                break;
            default:
                break;
        }
        if (!positionChanged && bs.Position == 0)
            bs.MoveLast();
        else if (!positionChanged)
            bs.MovePrevious();
    }
    private void nextItem()
    {
        BindingSource bs = null;
        switch (this.Type)
        {
            case AdminType.Channel:
                bs = channelBindingSource;
                break;
            default:
                break;
        }
        if (!positionChanged && bs.Position == bs.Count - 1)
            bs.MoveFirst();
        else if (!positionChanged)
            bs.MoveNext();
    }
