    public interface IData
    {
        IEnumerable<IWord> Vocabulary { get; }
    }
    public interface ITest
    {
        IWord FindWord(string word);
    }
