    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace HQ.Util.General
    {
    	/*
    		Usage:
    		            
               _glob = new FilterGlob(filterExpression, _caseSensitive);            
            
    
    			public bool IsMatch(string s)
    			{
    				return _glob.IsMatch(s);
    			}
    	*/
    
    
    	/// <summary>
    	/// Glob stand for: Pattern matching. Supported character are "?" and "*".
    	/// </summary>
    	public class FilterGlob
    	{
    		private readonly Regex pattern;
    
    		/// <summary>
    		/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.Glob"/> instance that matches the given pattern.
    		/// 
    		/// </summary>
    		/// <param name="pattern">The pattern to use. See <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.Glob"/> summary for
    		///             details of the patterns supported.</param><param name="caseSensitive">If true, perform a case sensitive match.
    		///             If false, perform a case insensitive comparison.</param>
    		public FilterGlob(string pattern, bool caseSensitive = true)
    		{
    			this.pattern = FilterGlob.GlobPatternToRegex(pattern, caseSensitive);
    		}
    
    		/// <summary>
    		/// Checks to see if the given string matches the pattern.
    		/// 
    		/// </summary>
    		/// <param name="s">String to check.</param>
    		/// <returns>
    		/// True if it matches, false if it doesn't.
    		/// </returns>
    		public bool IsMatch(string s)
    		{
    			return this.pattern.IsMatch(s);
    		}
    
    		private static Regex GlobPatternToRegex(string pattern, bool caseSensitive)
    		{
    			StringBuilder stringBuilder = new StringBuilder(pattern);
    			string[] strArray = new string[9]
    			{
    				"\\",
    				".",
    				"$",
    				"^",
    				"{",
    				"(",
    				"|",
    				")",
    				"+"
    			};
    
    			foreach (string oldValue in strArray)
    			{
    				stringBuilder.Replace(oldValue, "\\" + oldValue);
    			}
    
    			stringBuilder.Replace("*", ".*");
    			stringBuilder.Replace("?", ".");
    			stringBuilder.Insert(0, "^");
    			stringBuilder.Append("$");
    
    			RegexOptions options = caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
    
    			return new Regex(((object)stringBuilder).ToString(), options);
    		}
    
    	}
    }
