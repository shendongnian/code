      private static void Main(string[] args)
        {
            var updationIndex = 0;
            const string inputString = "On *Party1 #we will take some drinks, #eat very good food and #play ps3 games.# ";
            Func<string, char, char, string> getMyString = (givenString, skipTill, takeTill) =>
                {
                    var opString =
                        new string(
                            givenString.ToCharArray()
                                       .SkipWhile(x => x != skipTill)
                                       .Skip(1)
                                       .TakeWhile(x => x != takeTill)
                                       .ToArray());
                    updationIndex = inputString.IndexOf(givenString, StringComparison.CurrentCultureIgnoreCase)
                                    + opString.Length;
                    return opString;
                };
            var eventName = getMyString(inputString, '*', '#');
            Console.WriteLine("Event" + eventName);
            Console.WriteLine("Activities: ");
            while (updationIndex < inputString.Length)
            {
               var activity = getMyString(inputString.Remove(0, updationIndex), '#', '#');
               Console.WriteLine(activity);
               if (string.IsNullOrWhiteSpace(activity))
               {
                   break;
               }
        
            }
  
    }
