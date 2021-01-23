    while (true)
    {
        var e = new System.ComponentModel.CancelEventArgs();
        if (Call != null)
        {
            Call(this, e);
        }
        if (!e.Cancel)
        {
            // Initiate call
        }
        else
        {
            break;
        }
    }
