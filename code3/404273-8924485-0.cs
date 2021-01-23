    public delegate void UpdateProgressDelegate(string description, int scriptnumber);
    public void UpdateProgress(string description, int scriptnumber) {
        if (treeView.InvokeRequired) {
            treeView.Invoke(new UpdateProgressDelegate(UpdateProgress), new object[] { description, scriptnumber });
            return;
        }
        // Update the treeview
    }
