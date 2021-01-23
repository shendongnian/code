    public static class MainClass
    {
        public delegate void AddAttributeValueDelegate(string attribute, string value);
        public static void DoStuff(AddAttributeValueDelegate callback)
        {
            //Your Code here, e.g. ...
            string attribute = "", value = "";
            //foreach (EA.Element theElement in myPackage.Elements)
            //{
            //    foreach (EA.Attribute theAttribute in theElement.Attributes)
            //    {
            //        attribute = theAttribute.Name.ToString();
            //        value = theAttribute.Default.ToString();
            //        AddAttributeValue(attribute, value);
            //    }
            //}
            //
            // etc...
            callback(attribute, value);
        }
    }
