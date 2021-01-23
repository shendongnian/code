    public sealed class DynamicXml : DynamicObject
    {
        private XElement _xml;
        private DynamicXml(XElement xml)
        {
            _xml = xml;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            XElement xml = _xml.Element(binder.Name);
            if (xml == null)
            {
                result = null;
                return false;
            }
            result = new DynamicXml(xml);
            return true;
        }
        public static implicit operator XElement(DynamicXml xml)
        {
            return xml._xml;
        }
        
        public static explicit operator DynamicXml(XElement xml)
        {
            return new DynamicXml(xml);
        }
    }
