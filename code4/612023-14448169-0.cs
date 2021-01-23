    TextReader textReader = new StringReader( message );
    XmlDocument XDoc = new XmlDocument();
    XDoc.Load(textReader);
    XmlDocumentType XDType = XDoc.DocumentType;
    XDoc.RemoveChild(XDType);
    
    using (XmlReader xmlReader = new XmlTextReader(XDoc)) {
                    object deserializedObject = xmlSerializer.Deserialize( xmlReader );
    
                    theirObj ent = deserializedObject as theirObj ;
    
                    if (ent == null) {
                        throw new InvalidCastException("Unable to cast deserialized object to an theirObj object. {0}".FormatInvariant( deserializedObject));
                    }
    
                    return ent;
                }
