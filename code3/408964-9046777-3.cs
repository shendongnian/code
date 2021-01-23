    public interface IScriptGenerator
    {
        event Action<string> Script;
        void Generate(Data data, IEnumerable<IQuery> queries);
    }
