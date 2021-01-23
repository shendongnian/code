        public interface IDatHandler<T> : IDatHandler
            where T : IDatContainer
        {
            List<T> Items { get; set; }
        }
        public class ADEColorHandler : IDatHandler<IDatContainer>
        {
            public List<IDatContainer> Items
            {
                get;
                set;
            }
        }
