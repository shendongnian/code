    string sNoteType;
    if (objSelection.Items[2].Selected)
    {
        sNoteType = "OV ";
    }
    else if (objSelection.Items[5].Selected)
    {
        sNoteType = "EV ";
    }
    else if (objSelection.Items[4].Selected)
    {
        sNoteType = "LT ";
    }
    else if (objSelection.Items[3].Selected)
    {
        sNoteType = "BA ";
    }
    else if (objSelection.Items[0].Selected)
    {
        sNoteType = "LS ";
    }
    else if (objSelection.Items[1].Selected)
    {
        sNoteType = "FD ";
    }
    else
    {
        sNoteType = string.Empty;
    }
