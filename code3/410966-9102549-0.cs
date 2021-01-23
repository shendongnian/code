    string sNoteType;
    var items = objSelection.Items;
    
    var item0Selected = items[0].Selected;
    string item3NotSelectedValue;
    if (items[1].Selected)
    {
        item3NotSelectedValue = item0Selected ? "LS " : "FD ";
    }
    else
    {
        item3NotSelectedValue = item0Selected ? "LS " : string.Empty;
    }
    
    if (items[2].Selected)
    {
        sNoteType = "OV ";
    }
    else
    {
        if (items[5].Selected)
        {
            sNoteType = "EV ";
        }
        else
        {
            if (items[4].Selected)
            {
                sNoteType = "LT ";
            }
            else
            {
                if (items[3].Selected)
                {
                    sNoteType = "BA ";
                }
                else
                {
                    sNoteType = item3NotSelectedValue;
                }
            }
        }
    }
