    // StringExtensions.cs
    public class StringExtensions
    {
        public static string DisplayAsCommaListItem(
            this string str, object currentItem, object lastItem)
        {
            return currentItem != lastItem ? $"{str}, " : str;
        }
    }
