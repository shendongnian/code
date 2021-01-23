    public bool checkValue(
        int value,
        int result,
        Control controlG,
        Control controlW,
        Label label)
    {
        if (value == result)
        {
            ... Do stuff
            controlG.Visibility = Visibility.Visible;
        }
        else
        {
            ... Do other stuff
            controlW.Visibility = Visibility.Visible;
            label.Content = result.ToString();
        }
    }
