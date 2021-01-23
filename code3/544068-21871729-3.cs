    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Xml.Serialization;
    namespace Custom.Formatter
    {
        public class CustomXmlFormatter: MediaTypeFormatter
        {
            private  UTF8Encoding encoder;
    
            public CustomXmlFormatter()
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
                encoder = new UTF8Encoding(false, true);
            }
    
            public override bool CanReadType(Type type)
            {
                if (type == (Type)null)
                    throw new ArgumentNullException("type");
                
                //Type filtering
                if (type == typeof(SendEmailMessageResponse) || type == typeof(SendSmsMessageResponse))
                    return true;
                else
                    return false;
            }
    
            public override bool CanWriteType(Type type)
            {
                return true;
            }
    
            public override Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger formatterLogger)
            {
                return Task.Factory.StartNew(() =>
                        {
                            using (var streamReader = new StreamReader(stream, encoder))
                            {
                                var serializer = new XmlSerializer(type);
                                return serializer.Deserialize(streamReader);
                            }
                        });
            }
    
            public override Task WriteToStreamAsync(Type type, object value, Stream stream,    HttpContent content, TransportContext transportContext)
            {
                var serializer = new XmlSerializer(type);
                return Task.Factory.StartNew(() =>
                        {
                            using (var streamWriter = new StreamWriter(stream, encoder))
                            {
                                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                                ns.Add("", "");
                                serializer.Serialize(streamWriter, value, ns);
                            }
                        });
            }
        }
    }
