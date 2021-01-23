    SecurityToken token;
    using (StringReader sr = new StringReader(assertion))
    {
        using (XmlReader reader = XmlReader.Create(sr))
        {
            if (!reader.ReadToFollowing("saml:Assertion"))
            {
                throw new Exception("Assertion not found!");
            }
            SecurityTokenHandlerCollection collection = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection();
            token = collection.ReadToken(reader.ReadSubtree());
        }
    }
