    public static void SelectText(this DropDownList bob, string text)
    {
        try
        {
            if (bob.SelectedIndex >= 0)
                bob.Items[bob.SelectedIndex].Selected = false;
            bob.Items.FindByText(text).Selected = true;
        }
        catch
        {
            throw new GenericDropDownListException("value", text);
        }
    }
