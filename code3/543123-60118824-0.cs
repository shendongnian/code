            public static string GrammaticallyCorrectStringFrom(List<string> items, string prefaceTextWithNoSpaceAtEnd, string endingTextWithoutPeriod)
        {
            var returnString = string.Empty;
            if (items.Count != 0)
            {
                returnString = prefaceTextWithNoSpaceAtEnd + " ";
            }
            if (items.Count == 1)
            {
                returnString += string.Format("{0}", items[0]);
            }
            else if (items.Count == 2)
            {
                returnString += items[0] + " and " + items[1];
            }
            else if (items.Count > 2)
            {
                //remove the comma in the string.Format part if you're an anti-Oxford type
                returnString += string.Format("{0}, and {1}", string.Join(", ", items.Take(items.Count - 1)), items.Last());
            }
            if (String.IsNullOrEmpty(returnString) == false)
            {
                returnString += endingTextWithoutPeriod + ".";
            }           
            return returnString;
        }
