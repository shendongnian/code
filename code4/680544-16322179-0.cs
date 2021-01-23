    public string ContactPersonName
    {
        get
        {
            return Convert.ToString(
                (
                    Client.ContactPersons.Where(x => x.MainContactPerson == true).First())
                )
                ;
        }
    }
