    XElement PersonWithGender(XElement person)
    {
        string name = (string)p.Attribute("firstName") + (string)p.Attribute("lastName");
        XAttribute genderAttribute = new XAttribute("isMale", IsMale(name));
        return new XElement(genderAttribute, person.Attributes);
    }
    XElement PersonWithPhoneNumber(XElement person)
    {
        XElement contactDetails = person.Element("ContactDetails");
        XElement emailAddress = contactDetails.Element("EmailAddress");
        XElement phoneNumber = contactDetails.Element("PhoneNumber") ?? new XElement("PhoneNumber", "1122334455");
        return new XElement("ContactDetails", emailAddress, phoneNumber);
    }
