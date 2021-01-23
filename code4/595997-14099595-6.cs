    XElement documentElement = new XElement("Environment");
    foreach (DictionaryEntry envVariable in Environment.GetEnvironmentVariables())
    {
        documentElement.Add(new XElement(
            "Variable",
            new XAttribute("Name", envVariable.Key),
            envVariable.Value
            ));
    }
    Console.WriteLine(documentElement);
