    public void UserDeletingEvent(object sender, EventArg e)
    {
        if (e.Row.Index >= 0)
        {
            BindingSource.RemoveAt(e.Row.Index);
        }
    }
