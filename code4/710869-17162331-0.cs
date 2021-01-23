    public enum Language
    {
        English,
        French,
        Spanish
    }
    public static class Enum
    {
        public static IEnumerable<T> GetItems<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
    public class ViewModel
    {
        public Language Language
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> Languages
        {
            get
            {
                return Enum.GetItems<Language>().Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() });
            }
        }
    }
