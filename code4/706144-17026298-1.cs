    static IEnumerable<TimeSeries> ReadTimeSeries(TextReader source)
    {
        using (var reader = XmlReader.Create(source, new XmlReaderSettings {
                         IgnoreWhitespace = true }))
        {
            reader.MoveToContent();
            reader.ReadStartElement("TimeSeries");
            while(reader.Read() && reader.NodeType == XmlNodeType.Element
                        && reader.Depth == 1)
            {
                using (var subtree = reader.ReadSubtree())
                {
                    var el = XElement.Load(subtree);
                    var obj = new TimeSeries
                    {
                        ObjectId = (Guid) el.Attribute("ObjectId"),
                        // note: datetime is not xml format; need to parse - this
                        // should probably be more explicit
                        Date = DateTime.Parse((string) el.Attribute("Date")),
                        Source = (string) el.Attribute("Source"),
                        Type = (string)el.Attribute("Type"),
                        Value = (decimal)el.Attribute("Value")
                    };
                    yield return obj;
                }
            }
        }
    }
