class ContactNo
{
    public string ContactType { get; set; }
    public string ContactNo { get; set; }
    public ContactNo(string type, string no)
    {
        ContactType = type;
        ContactNo = no;
    }
}
Or (with the properties) initialize it like this :
    ContactNo contact = { ContactType = "The type", ContactNo = "The No" };
