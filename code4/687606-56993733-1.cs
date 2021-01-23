    catch (FaultException e)
    {
        var errorElement = XElement.Parse(e.CreateMessageFault().GetReaderAtDetailContents().ReadOuterXml());
        var errorDictionary = errorElement.Elements().ToDictionary(key => key.Name.LocalName, val => val.Value);
        var errorDetails = string.Join(";", errorDictionary);
    }
