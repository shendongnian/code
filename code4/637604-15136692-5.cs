    // The method is contained in a Form (winforms)
    private void UpdateAnnotations()
    {
        if (this.InvokeRequired)
            this.Invoke(new Action(UpdateAnnotations));
        else
        {
            MessageBox.Show("Method is called");
        }
    }
