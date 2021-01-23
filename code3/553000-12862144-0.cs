    public class WordsWithValue
    {
        public string[] Words { get; set; }
        public object Value { get; set; }
    }
    public IDictionary<string, object[]> GetValuesForWord(IEnumerable<WordsWithValue> wordsWithValues)
    {
        return wordsWithValues.SelectMany(wwv => wwv.Words.Select(word => Tuple.Create(word, wwv.Value)))
                                .GroupBy(tuple => tuple.Item1, tuple => tuple.Item2, (word, values) => Tuple.Create(word, values.ToArray()))
                                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
    }
