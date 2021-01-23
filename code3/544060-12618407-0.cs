    public CustomXmlFormatter()
    {
        SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
        SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
        Encoding = new UTF8Encoding(false, true);
    }
    protected override bool CanReadType(Type type)
    {
        if (type == (Type)null)
            throw new ArgumentNullException("type");
    
        if (type == typeof(IKeyValueModel))
            return false;
    
        return true;
    }
    
    protected override bool CanWriteType(Type type)
    {
        return true;
    }
    
    protected override Task OnReadFromStreamAsync(Type type, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext)
    {
        return Task.Factory.StartNew(() =>
                {
                    using (var streamReader = new StreamReader(stream, Encoding))
                    {
                        var serializer = new XmlSerializer(type);
                        return serializer.Deserialize(streamReader);
                    }
                });
    }
    
    protected override Task OnWriteToStreamAsync(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext, System.Net.TransportContext transportContext)
    {
        var serializer = new XmlSerializer(type);
        return Task.Factory.StartNew(() =>
                {
                    using (var streamWriter = new StreamWriter(stream, Encoding))
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", "");
                        serializer.Serialize(streamWriter, value, ns);
                    }
                });
        }
    }
