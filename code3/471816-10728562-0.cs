    public class FindDogConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<Pet> pets = value as IEnumerable<Pet>;
            return pets.Single(p => p.AnimalType == "Dog").Name;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
}
