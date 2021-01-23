    public class Utility
    {
        public static ServiceProviderTic DeserializeData(XElement request)
        {
            var ser = new XmlSerializer(typeof(ServiceProviderTic));
            return (ServiceProviderTic)ser.Deserialize(request.CreateReader());
        }
        public static XElement SerializeData(ServiceProviderTic response)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(ServiceProviderTic));
                    xmlSerializer.Serialize(streamWriter, response);
                    return Utility.RemoveAllNamespaces(XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray())));
                }
            }
        }
        public static XElement RemoveAllNamespaces(XElement source)
        {
            return !source.HasElements
                       ? new XElement(source.Name.LocalName)
                       {
                           Value = source.Value
                       }
                       : new XElement(source.Name.LocalName, source.Elements().Select(el => RemoveAllNamespaces(el)));
        }
    }
