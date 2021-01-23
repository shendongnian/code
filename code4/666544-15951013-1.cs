    int _selectCounter = 0;
    const int SELECT_TIMER_LENGTH = 500;
    async private void TextBox1_SelectionChanged(object sender, RoutedEventArgs e)
    {
        // mySelectCount is the number of selection changed events that have fired.
        // If you are really paranoid, you will want to make sure that if
        // selectCounter reaches MAX_INT, that you reset it to zero.
        int mySelectCount = ++_selectCounter;
        // start the timer and wait for it to finish
        await Task.Delay(SELECT_TIMER_LENGTH);
        // If equal (mySelectCount == _selectCounter),
        // this means that NO select change events have fired
        // during the delay call above. We only do the
        // programmatic selection when this is the case.
        // Feel free to adjust SELECT_TIMER_LENGTH to suit your needs.
        if (mySelectCount == _selectCounter)
        {
            this.TextBox2.Select(this.TextBox1.SelectionStart, this.TextBox1.SelectionLength);
        }
    }
