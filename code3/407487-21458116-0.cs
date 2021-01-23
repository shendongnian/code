    	private const string XmlError = "There is an error in XML document ";
    	private const string InstanceValidationError = "Instance validation error:";
		private static readonly Regex XmlErrorRegex = new Regex("There is an error in XML document \\((\\d+), (\\d+)\\).");
    	private static readonly Regex InstanceValidationErrorRegex = new Regex("Instance validation error: '(\\S+)' is not a valid value for (\\S+).");
    	private const string TagFinderString = "\\>{0}\\</(\\S+)\\>";
		
    	/// <summary>
        /// Helper method to deserialize xml message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public T Deserialize(string message)
        {
            var result = default(T);
            if (!string.IsNullOrEmpty(message))
            {
                using (var reader = new StringReader(message))
                {
					try
					{
						result = (T)_serializer.Deserialize(reader);
					}
					catch (InvalidOperationException ex)
					{
						if (ex.Message.StartsWith(XmlError))
						{
							if(ex.InnerException != null && ex.InnerException.Message.StartsWith(InstanceValidationError))
							{
								var instanceValidationErrorMatches = InstanceValidationErrorRegex.Matches(ex.InnerException.Message);
								if (instanceValidationErrorMatches.Count > 0)
								{
									var locationMatches = XmlErrorRegex.Matches(ex.Message);
									var startIndex = GetStartIndex(message, locationMatches);
									var match = instanceValidationErrorMatches[0];
									if(match.Groups.Count > 0)
									{
										var toRemove = GetToRemove(message, match, startIndex);
										return Deserialize(message.Replace(toRemove, string.Empty));
									}
								}
							}
						}
					}
                }
            }
            return result;
        }
    	private static string GetToRemove(string message, Match match, int startIndex)
    	{
    		var value = match.Groups[1];
    		var tagFinder = new Regex(string.Format(TagFinderString, value));
    		var tagFinderMatches = tagFinder.Matches(message.Substring(startIndex));
    		var tag = tagFinderMatches[0].Groups[1];
    		return string.Format("<{0}>{1}</{0}>", tag, value);
    	}
    	private static int GetStartIndex(string message, MatchCollection locationMatches)
    	{
    		var startIndex = 0;
    		if (locationMatches.Count > 0)
    		{
    			var lineNumber = int.Parse(locationMatches[0].Groups[1].Value);
    			var charIndex = int.Parse(locationMatches[0].Groups[2].Value);
    			using (var locationFinder = new StringReader(message))
    			{
    				for (var i = 1; i < lineNumber; i++)
    				{
    					startIndex += locationFinder.ReadLine().Length;
    				}
    			}
    			startIndex += charIndex;
    		}
    		return startIndex;
    	}
