    var multiplied = card.Select(char.GetNumericValue)
                         .Zip(card_m.Indefinite(), (a,b) => a*b);
    public static class Extensions
    {
        public static IEnumerable<int> Indefinite(this int[] source)
        {
            int i = 0;
            while (true)
                yield return source[i++ % source.Length];
        }
    }
