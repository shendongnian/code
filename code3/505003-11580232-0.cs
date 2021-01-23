    public void disableFormControls()
    {
        if (InvokeRequired)
        {
            this.Invoke(new Action(disableFormControls));
            return;
        }
        groupBoxInput.Enabled = false;
        groupBoxOutput.Enabled = false;
        btnGen.Enabled = false;
        btnReset.Enabled = false;
    }
