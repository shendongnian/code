    public class CombineFullNameAndPhoneExtensionMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values,
                              Type targetType,
                              object parameter,
                              System.Globalization.CultureInfo culture)
        {
            if (values[0] as string != null)
            {
                string fullName = (string)values[0] ?? "Unknown";
                string phoneExtension = (string)values[1] ?? "Unknown";
                string namePlusExtension = fullName.Trim() + "    Phone: " + phoneExtension.Trim();
                return namePlusExtension;
            }
            return null;
        }
        public object[] ConvertBack(object value,
                                    Type[] targetTypes,
                                    object parameter,
                                    System.Globalization.CultureInfo culture)
        {
            NotesContact c = (NotesContact)value;
            string[] returnValues = { c.FullName.Trim(), c.PhoneExtension.Trim() };
            return returnValues;
        }
    }
    public class CombineLastNameFirstNameAndPhoneExtensionMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values,
                             Type targetType,
                             object parameter,
                             System.Globalization.CultureInfo culture)
       {
           if (values[0] as string != null)
           {
               string lastName = (string)values[0] ?? "Unknown";
               string firstName = (string)values[1] ?? "Unknown";
               string phoneExtension = (string)values[2] ?? "Unknown";
               string lastCommaFirstPlusExtension = lastName.Trim() + ", " + firstName.Trim() + "    Phone: " + phoneExtension.Trim();
               return lastCommaFirstPlusExtension;
           }
           return null;
       }
       public object[] ConvertBack(object value,
                                   Type[] targetTypes,
                                   object parameter,
                                   System.Globalization.CultureInfo culture)
       {
           throw new NotImplementedException();
       }
    }
