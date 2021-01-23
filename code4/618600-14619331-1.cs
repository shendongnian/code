    string res = "";
    int i = 0;
    while (i < tblAttributes.Count && (ExcludeColumn(tblAttributes[i].Name) || (Primary(tblAttributes[i].Name)))
        i++;
    if (i < tblAttributes.Count) res += tblAttributes[i].Name;
    for (; i < tblAttributes.Count; i++)
    {
        if (!ExcludeColumn(tblAttributes[i].Name) && !(Primary(tblAttributes[i].Name))
            res += ", " + tblAttributes[i].Name;
    }
