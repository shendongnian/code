    public static class Extensions
    {
        public static IEnumerable<int> IndecesOf(this string text, string pattern)
        {
            var items = text.Split(' ');
            for(int i = 0; i < items.Count(); i++)
                if(items[i].ToLower().Contains(pattern));
                    yield return i + 1;
        }
    }
