    public class DynamicXMLNode : DynamicObject
    {
        XElement node;
        //all the other stuff necessary...
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            string name = (string)indexes[0];
            result = node.Attribute(name); //maybe check for null here
            return true;
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            string name = (string)indexes[0];
            node.SetAttributeValue(name, value);
            return true;
        }
    }
