    // Note camelCase for variable names, not PascalCase.
    var query = document.Descendants("CodeType")
                        .Where(type => type.Value == codeType)
                        .Select(type => (string) type.Parent.Element("CodeID"))
                        .Where(id => id == null)
                        .Distinct();
