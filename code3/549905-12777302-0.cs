    public class Note
    {
        public string Name { get; set; }
        public string Tags { get; set; }
    }
    public class NoteItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Note)
            {
                Note note = value as Note;
                // Return a value based on parameter (when ConverterParameter is specified)
                if (parameter != null)
                {
                    string param = parameter as string;
                    if (param == "name")
                    {
                        return note.Name;
                    }
                    else if (param == "tags")
                    {
                        return note.Tags;
                    }
                }
                // Return both name and tags (when no parameter is specified)
                return string.Format("{0}: {1}", note.Name, note.Tags);
            }
            // Gracefully handle other types
            // Optionally, throw an exception
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
