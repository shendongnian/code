    private static IEnumerable<string> FindCommonContent(string[] strings, int minimumMatchLength)
    {
        string sharedContent = "";
        while (strings.All(x => x.Length > 0))
        {
            var item1FirstCharacter = strings[0][0];
            if (strings.All(x => x[0] == item1FirstCharacter))
            {
                sharedContent += item1FirstCharacter;
                for (int index = 0; index < strings.Length; index++)
                    strings[index] = strings[index].Substring(1);
                continue;
            }
                
            if (sharedContent.Length >= minimumMatchLength)
                yield return sharedContent;
            sharedContent = "";
            // If the first minMatch characters of a string aren't in all the other strings, consume the first character of that string
            for (int index = 0; index < strings.Length; index++)
            {
                string testBlock = strings[index].Substring(0, Math.Min(minimumMatchLength, strings[index].Length));
                if (!strings.All(x => x.Contains(testBlock)))
                    strings[index] = strings[index].Substring(1);
            }
        }
        if (sharedContent.Length >= minimumMatchLength)
            yield return sharedContent;
    }
