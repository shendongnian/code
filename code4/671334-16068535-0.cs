    public string Foo(string countryCode, string areaCode, string phoneNumber)
    {
        if (string.IsNullOrEmpty(countryCode)) throw new ArgumentNullException("countryCode");
        if (string.IsNullOrEmpty(areaCode)) throw new ArgumentNullException("areaCode");
        if (string.IsNullOrEmpty(phoneNumber)) throw new ArgumentNullException("phoneNumber");
        return string.Format(......);
    }
