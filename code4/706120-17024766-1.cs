    public IEnumerable<PhoneNumber> GetPhoneDirectory()
    {
        using (PhoneBookDataContext db = new PhoneBookDataContext())
        {
            return db.PhoneNumbers.Where(d => d.Site == _site).ToList();
        }
    }
