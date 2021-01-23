        // let Msg be a dumb data object
        public interface IMsg
        {
            int Id { get; }
            byte[] Data { get; }
        }
        // and then keep their types weakly-typed
        private readonly Dictionary<int, String> MessageNames;
        
        // and you can also provide various type-based functionality
        // during runtime
        private readonly Dictionary<int, IParser> Parsers;
