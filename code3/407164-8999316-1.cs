    using System;
    using System.Collections;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    
    public static class Program
    {
        static void Main()
        {
            // the loop here is from your comment
            for (int i = 0; i < 10000000; i++) { ToXMLString("test", string.Format("test")); Console.WriteLine(i); }
        }
    
        // why is this Hashtable? due to the threading semantics!
        private static readonly Hashtable serializerCache = new Hashtable();
    
        public static string ToXMLString(object obj, string nodeName)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            Type type = obj.GetType();
            var cacheKey = new { Type = type, Name = nodeName };
            XmlSerializer xmlSerializer = (XmlSerializer)serializerCache[cacheKey];
            if (xmlSerializer == null)
            {
                lock (serializerCache)
                { // double-checked
                    xmlSerializer = (XmlSerializer)serializerCache[cacheKey];
                    if (xmlSerializer == null)
                    {
                        xmlSerializer = new XmlSerializer(type, new XmlRootAttribute(nodeName));
                        serializerCache.Add(cacheKey, xmlSerializer);
                    }
                }
            }
            try
            {
    
                StringWriter sw = new StringWriter();
                using (XmlWriter writer = XmlWriter.Create(sw,
                    new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true }))
                {
                    // Don't include XML namespace
                    XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
                    xmlnsEmpty.Add("", "");
                    xmlSerializer.Serialize(writer, obj, xmlnsEmpty);
                }
                return sw.ToString();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
    }
