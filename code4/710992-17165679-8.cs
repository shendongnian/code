    public void RemoveDuplicates() // think about better name
    {
         if (IsDuplicateOfSuburb(AddressLine2))
             AddressLine2 = null;
         if (IsDuplicateOfSuburb(AddressLine3))
             AddressLine3 = null;
    }
    private bool IsDuplicateOfSuburb(string addressLine)
    {
        if (addressLine == null)
            return false;
        return (addressLine.ToLower() == Suburb.ToLower();
    }
