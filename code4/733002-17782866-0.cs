    public static class WineCellarExtensions
    {
        public static IEnumerable<WineCellar> Except(this List<WineCellar> cellar, IEnumerable<string> wines)
        {
            foreach (var wineCellar in cellar)
            {
                if (!wines.Contains(wineCellar.wine))
                {
                    yield return wineCellar;
                }
            }
        }
    }
