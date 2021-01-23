    public interface ICursorCreator {
        int CreateCursor(string sqlCmd);
    }
    public abstract class CursorReader
    {
        private readonly int m_rowCount;
        protected CursorReader(string sqlCmd, ICursorCreator creator)
        {
             m_rowCount = creator.CreateCursor(sqlCmd); //no longer a virtual call 
        }
        //protected abstract int CreateCursor(string sqlCmd);//no longer needed
        
        //...other (non-abstract) methods that assume a cursor exists
    }
    //move the logic of creating a cursor in a separate class, and pass an instance of that to the base class. 
    public SqlCursorCreator: ICursorCreator {
        private SqlConnection m_sqlConnection;
        public SqlCursorCreator(SqConnection conn){
            m_sqlConnection = conn;
        }
        public int CreateCursor(string sqlCmd)
        {
            var cursor = new SqlCursor(sqlCmd, m_sqlConnection); 
            cursor.Create();
            return cursor.Count();
        }
    }
    
    public class SqlCursorReader : CursorReader
    {
        //private SqlConnection m_sqlConnection;//no longer needed
        
        //by saving the connection in the factory, it will be available when needed later
        public SqlCursorReader(string sqlCmd, SqlConnection sqlConnection)
            :this(sqlCmd, new SqlCursorCreator(sqlConnection))
        { }
        protected SqlCursorReader(string sqlCmd, SqlCursorCreator creator)
            : base(sqlCmd, creator)
        { }
    }
