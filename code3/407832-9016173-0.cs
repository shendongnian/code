    var parameters = new Dictionary<String, XDocument>();
    parameters["parametersXDoc"] = new XDocument(new XElement(file.Root.Element("ArrayOfParameter")));
    parameters["criteriaXDoc"] = new XDocument(new XElement(file.Root.Element("ArrayOfCriteria")));
    parameters["sortfieldsXDoc"] = new XDocument(new XElement(file.Root.Element("ArrayOfSortField")));
    parameters["selectedfieldsXDoc"] = new XDocument(new XElement(file.Root.Element("ArrayOfSelectedField")));
    parameters["reportlayoutXDoc"] = new XDocument(new XElement(file.Root.Element("ReportLayout")));
    parameters["dictionaryXDoc"] = new XDocument(new XElement(file.Root.Element("Dictionary")));
