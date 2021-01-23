    public class Parser
    {
        IBase Parse(XDocument xDocument)
        {
            TypeInfoEnum key = GetKeyForXDocument(xDocument);
            IBase x = DictionaryWithParsers[key](xDocument);
            return x;
        }
    }
