    static void IterateDictionary(Dictionary<string, object> dictionary)
        {
            foreach (var pair in dictionary)
            {
                System.Console.WriteLine("Processing key: " + pair.Key);
                object value = pair.Value;
                var subDictionary = value as Dictionary<string, object>;
                if (subDictionary != null)
                {
                    // recursive call to process embedded dictionary
                    // warning: stackoverflowexception might occur for insanely embedded data: dictionary in dictionary in dictionary in . etc
                    IterateDictionary(subDictionary);
                }
                else
                {
                    // process data
                    System.Console.WriteLine("data: {0}", value);
                }
            }
        }
