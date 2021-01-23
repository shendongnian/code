    int updationIndex = 0; 
    Func<string, char, string> getMyString1 = (givenString, takeTill) =>
             {
                var opString =
                    new string(
                        givenString.ToCharArray()
                                   .TakeWhile(x => x != takeTill)
                                   .ToArray());
                updationIndex = inputString.IndexOf(givenString, StringComparison.CurrentCultureIgnoreCase)
                                + opString.Length;
                return opString;
            };
            var smeal = getMyString1(inputString, '{');
            Console.WriteLine("Meal: " + smeal);
            while (updationIndex < inputString.Length)
            {
                var sReceipt = getMyString(inputString.Remove(0, updationIndex), ':', '}');
                Console.WriteLine("sReceipt: "+ sReceipt);
                if (string.IsNullOrWhiteSpace(sReceipt))
                {
                    break;
                }
            }
