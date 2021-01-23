    string res = "";
    for (int i = 0; i < tblAttributes.Count - 1; i++)
    {
        if (!ExcludeColumn(tblAttributes[i].Name) && !(Primary(tblAttributes[i].Name))
            res += tblAttributes[i].Name + ", ";
    }
    i = tblAttributes.Count - 1;
    if (tblAttributes.Count > 0 && !ExcludeColumn(tblAttributes[i].Name) && !(Primary(tblAttributes[i].Name))
        res += tblAttributes[i].Name
