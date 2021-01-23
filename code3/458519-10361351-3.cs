    public static class Extensions
    {
        public static T DeepCopy<T>(this T element)
        {
            return (T)XamlReader.Load(new XmlTextReader(new 
                   StringReader(XamlWriter.Save(element))));
        }
    }
