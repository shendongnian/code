    if (xml.IsStartElement("Results"))
    {
        // Be careful so that the cursor will be left after the closing tag of the 'Results' element, even if Results.FromXml throws.
        using (XmlReader resultsElement = xml.ReadSubtree())
        {
            resultsElement.Read();
            try 
            {
                results = Results.FromXml(resultsElement);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Reading results xml went wrong {0}", e.Message);
            }
        }
        xml.ReadEndElement("Results");
    }
