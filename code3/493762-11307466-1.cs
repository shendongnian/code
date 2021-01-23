    private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        object someArgsInterestingForTheMethod = new object();
    
        e.Cancel = !((IManagedForm)this).CanIBeClosed(someArgsInterestingForTheMethod);
    }
    
    public bool CanIBeClosed(object someParams)
    {
        // This flag would control if this window has not pending changes.
        bool meetConditions = ValidateClosingConditions(someParams);
        // If there were pending changes, but the user decided to not discard
        // them an proceed saving, this flag says to the parent that this form
        // is done, therefore is ready to be closed.
        bool iAmReadyToBeClosed = true;
        
        // There are unsaved changed. Ask the user what to do.
        if (!meetConditions)
        {
            // YES => OK Save pending changes and exit.
            // NO => Do not save pending changes and exit.
            // CANCEL => Cancel closing, just do nothing.
            switch (MessageBox.Show("Save changes before exit?", "MyChildForm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    // Store data and leave...
                    iAmReadyToBeClosed = true;
                    break;
                case DialogResult.No:
                    // Do not store data, just leave...
                    iAmReadyToBeClosed = true;
                    break;
                case DialogResult.Cancel:
                    // Do not leave...
                    iAmReadyToBeClosed = false;
                    break;
            }
        }
        return iAmReadyToBeClosed;
    }
    
    // This is just a dummy method just for testing
    public bool ValidateClosingConditions(object someParams)
    {
        Random rnd = new Random();
        return ((rnd.Next(10) % 2) == 0);
    }
