    using System;
    using System.Collections.Generic;
    using System.Xml;
    
    namespace XmlParserLibrary
    {
        public sealed class XmlParser
        {
            private readonly IDictionary<Type, IXmlParser> parsers = new Dictionary<Type, IXmlParser>()
            {
                { typeof(string), new StringXmlParser() }
            };
    
            public T Parse<T>(XmlReader reader)
            {
                return (T)this.Parse(reader, typeof(T));
            }
    
            public object Parse(XmlReader reader, Type type)
            {
                // Position on element.
                while (reader.Read() && reader.NodeType != XmlNodeType.Element) ;
    
                return GetParser(type).Parse(reader);
            }
    
            private IXmlParser GetParser(Type type)
            {
                IXmlParser xmlParser;
                if (!this.parsers.TryGetValue(type, out xmlParser))
                    this.parsers.Add(type, xmlParser = this.CreateParser(type));
    
                return xmlParser;
            }
    
            private IXmlParser CreateParser(Type type)
            {
                var xmlParserAttribute = Attribute.GetCustomAttribute(type, typeof(XmlParserAttribute)) as XmlParserAttribute;
                return xmlParserAttribute != null ? Activator.CreateInstance(xmlParserAttribute.XmlParserType) as IXmlParser : new FallbackXmlParser(this, type);
            }
        }
    
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
        public sealed class XmlParserAttribute : Attribute
        {
            public Type XmlParserType { get; private set; }
    
            public XmlParserAttribute(Type xmlParserType)
            {
                this.XmlParserType = xmlParserType;
            }
        }
    
        public interface IXmlParser
        {
            object Parse(XmlReader reader);
        }
    
        internal sealed class StringXmlParser : IXmlParser
        {
            public object Parse(XmlReader reader)
            {
                return reader.ReadElementContentAsString();
            }
        }
    
        internal sealed class FallbackXmlParser : IXmlParser
        {
            private readonly XmlParser xmlParser;
            private readonly Type type;
    
            public FallbackXmlParser(XmlParser xmlParser, Type type)
            {
                this.xmlParser = xmlParser;
                this.type = type;
            }
    
            public object Parse(XmlReader reader)
            {
                var item = Activator.CreateInstance(this.type);
    
                while (reader.Read())
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            var propertyInfo = this.type.GetProperty(reader.LocalName);
                            var propertyValue = this.xmlParser.Parse(reader.ReadSubtree(), propertyInfo.PropertyType);
                            propertyInfo.SetValue(item, propertyValue, null);
                            break;
                    }
    
                return item;
            }
        }
    }
