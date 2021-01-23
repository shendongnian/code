    public interface IServerFuncs<T> where T : MasterClass
    {
    	Table<T> getTable();
    	//*cut* other stuff here
    }
    public class DefaultFuncs<T> : IServerFuncs<T> where T : MasterClass
    {    
        Table<T> table;
        
        public DefaultFuncs(Table<T> table)
        {
            this.table = table;
        }
        
        public Table<T> getTable()
        {
            return table;
        }
    }
