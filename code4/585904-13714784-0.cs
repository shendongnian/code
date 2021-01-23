    namespace Core.BaseLibrary.Extensions
    {
        public static class StringExtensions
        {
    		/// <summary>
    		/// Returns a count of words in the passed string.
    		/// </summary>
    		/// <param name="stringToCount">The string to count.</param>
            /// <returns>An integer containing the number of words in the string</returns>
    		public static int WordCount(this string stringToCount)
    		{
                return Regex.Matches(stringToCount, @"[\S]+").Count;
    		}
        }
    }
