    int sbntmsk;
    if (RBSBtn.Checked)
    {
        sbntmsk = 29;
    }
    else if (BTSBtn.Checked)   // Notice the ELSE - IF
    {
        sbntmsk = 30;
    }
    else
    {
        sbntmsk = 0;  // a default value
    }
    string subntmsk = String.Empty;   // initialize with empty
    subntmsk = sbntmsk.ToString();
