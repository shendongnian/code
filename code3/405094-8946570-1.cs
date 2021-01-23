    class Xml2AdressConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            XmlElement xmlElt = value as XmlElement;
            
            if (xmlElt != null)
            {
                string str, attName;
                XElement xElt;
                attName = parameter as string;
                xElt= XElement.Load(xmlElt.CreateNavigator().ReadSubtree());
                str = "";
                foreach (XElement x in xElt.Descendants(attName))
                {
                     str = x.Value;
                }
                return str;
            }
            return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
