    public string ContactType { get; set; }
    public string ContactNo { get; set; }
    public ContactNo(string type, string no)
    {
        ContactType = type;
        ContactNo = no;
    }
