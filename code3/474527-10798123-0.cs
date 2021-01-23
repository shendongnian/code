    protected virtual bool ProcessKeyEventArgs(ref Message m)
    {
    	// ...
    	if (e.SuppressKeyPress)
        {
            this.RemovePendingMessages(0x102, 0x102);
            this.RemovePendingMessages(0x106, 0x106);
            this.RemovePendingMessages(0x286, 0x286);
        }
        return e.Handled;
    }
