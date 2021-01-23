    public void ClearUndo()
    {
        if (base.IsHandleCreated)
        {
            base.SendMessage(205, 0, 0);
        }
    }
