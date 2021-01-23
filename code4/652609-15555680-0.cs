    using System.Xml;
    using System.IdentityModel.Tokens;
    
    namespace YOUR.SPACE
    {
        public class Saml2Serializer : Saml2SecurityTokenHandler
        {
            public Saml2Serializer()
            {
                Configuration = new SecurityTokenHandlerConfiguration()
                    {
    
                    };
            }
    
            public void WriteSaml2Assertion(XmlWriter writer, Saml2Assertion data)
            {
                base.WriteAssertion(writer, data);
            }
        }
    }
