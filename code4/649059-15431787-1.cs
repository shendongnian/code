    public static Person FromXElement(XElement element)
    {
        return new Person
        {
            Id = (int) element.Element("PersonId"),
            Name = (string) element.Element("PersonName"),
            Surname = (string) element.Element("PersonSurname"),
            Age = (int) element.Element("PersonAge")
        };
    }
