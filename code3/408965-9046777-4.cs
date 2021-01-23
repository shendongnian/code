    public class SampleScriptGenerator : IScriptGenerator
    {
        private readonly ISerializer serializer;
        public event Action<string> Script;
        public SampleScriptGenerator(ISerializer serializer)
        {
            this.serializer = serializer;
        }
        public void Generate(Data data, IEnumerable<IQuery> queries)
        {
            foreach (string serialized in from query in queries select query.Process(data) into result where result != null select serializer.Serialize(result))
            {
                OnSerialize(serialized);
            }
        }
        private void OnSerialize(string serialized)
        {
            var handler = Script;
            if (handler != null) handler(serialized);
        }
    }
