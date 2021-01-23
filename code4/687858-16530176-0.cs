    public interface IDatabaseOperation
    {
        void Execute();
    }
    public class LoadListDatabaseOperation : IDatabaseOperation
    {
        private List<string> _itemList;
        public LoadListDatabaseOperation(List<string> itemList)
        {
            _itemList = itemList;
        }
        public void Execute()
        {
            ...
            // Fill the list here
            ...
        }
    }
