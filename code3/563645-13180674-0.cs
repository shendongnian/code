    public class Copy<T>
    {
        public static T DeepCopy<T>(T element)
        {
            string xaml = XamlWriter.Save(element);
            StringReader xamlString = new StringReader(xaml);
            XmlTextReader xmlTextReader = new XmlTextReader(xamlString);
            var DeepCopyobject = (T)XamlReader.Load(xmlTextReader);
            return DeepCopyobject;
        }
    }
