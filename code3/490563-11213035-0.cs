    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
    			List<string> testList = CreateTestList();
    			const string filter = "abc";
    
    			TimeNewListMethod(FilterIntoNewListWithLinq, testList, filter);
    			TimeInPlaceMethod(FilterInPlaceWithLinq, testList, filter);
    
    			TimeNewListMethod(FilterIntoNewListWithForEach, testList, filter);
    
    			TimeInPlaceMethod(FilterInPlaceWithRemoveAll, testList, filter);
    
    			Console.Read();
            }
    
    		public static void TimeInPlaceMethod(Action<List<string>, string> testMethod, List<string> toFilter, string filter)
    		{
    			List<string> toFilterCopy = new List<string>(toFilter);
    			DateTime time = DateTime.Now;
    			testMethod(toFilterCopy, filter);
    			Console.WriteLine(DateTime.Now - time);
    		}
    
    		public static void TimeNewListMethod(Func<List<string>, string, List<string>> testMethod, List<string> toFilter, string filter)
    		{
    			List<string> toFilterCopy = new List<string>(toFilter);
    			List<string> resultList;
    			DateTime time = DateTime.Now;
    			resultList = testMethod(toFilterCopy, filter);
    			Console.WriteLine(DateTime.Now - time);
    		}
    
    		public static List<string> FilterIntoNewListWithLinq(List<string> toFilter, string filter)
    		{
    			return toFilter.Where(element => element.IndexOf(filter) > -1).ToList();
    		}
    
    		public static void FilterInPlaceWithLinq(List<string> toFilter, string filter)
    		{
    			toFilter = toFilter.Where(element => element.IndexOf(filter) > -1).ToList();
    		}
    		
    		public static List<string> FilterIntoNewListWithForEach(List<string> toFilter, string filter)
    		{
    			List<string> returnList = new List<string>(toFilter.Count);
    			foreach (string word in toFilter)
    			{
    				if (word.IndexOf(word[0]) > -1)
    				{
    					returnList.Add(word);
    				}
    			}
    
    			return returnList;
    		}
    		
    		public static void FilterInPlaceWithRemoveAll(List<string> toFilter, string filter)
    		{
    			toFilter.RemoveAll(element => element.IndexOf(filter) == -1);
    		}
    
    		public static List<string> CreateTestList(int elements = 10000, int wordLength = 6)
    		{
    			List<string> returnList = new List<string>();
    			StringBuilder nextWord = new StringBuilder();
    			
    			for (int i = 0; i < elements; i++)
    			{
    				for (int j = 0; j < wordLength; j++)
    				{
    					nextWord.Append(RandomCharacter());
    				}
    				returnList.Add(nextWord.ToString());
    				nextWord.Clear();
    			}
    
    			return returnList;
    		}
    
    		public static char RandomCharacter()
    		{
    			return (char)('a' + rand.Next(0, 25));
    		}
    
    		public static Random rand = new Random();
    	}
    }
