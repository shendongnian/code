    list.Sort(delegate(ClientContact c1, ClientContact c2)
    {
        return !string.IsNullOrEmpty(c1.LastName) ?
            c1.LastName.CompareTo(c2.LastName) :
            c1.EntityName.CompareTo(c2.LastName);         
    });
