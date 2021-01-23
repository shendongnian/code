    class DataRepository
    {
        public SetDataHelper setData()
        { return new SetDataHelper(); }
    
        public ModifyDataHelper modifyData()
        { return new ModifyDataHelper(); }
    
        public GetDataHelper getData()
        { return new GetDataHelper(); }
    }
    
    class SetDataHelper
    {
        public void insertNewAccount(username, password) { ... }
    }
    
    class ModifyDataHelper
    {
        public void deleteAccount(username, password) { ... }
    }
    
    class GetDataHelper
    {
        public Account getAccount() { ... }
    }
