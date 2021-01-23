    public void AddCustomerInfo(string firstName, string lastName, int index, XElement root)
    {
        XElement firstNameInfo = new XElement("FirstName_" + index);
        firstNameInfo.Value = firstName;
        XElement lastNameInfo = new XElement("LastName_" + index);
        lastNameInfo.Value = lastName;
        root.Add(firstNameInfo);
        root.Add(lastNameInfo);
    }
