    public static Dog FromXElement(XElement element)
    {
        // Or whatever...
        return new Dog((string) element.Element("Name"),
                       (double) element.Element("Weight"));
    }
