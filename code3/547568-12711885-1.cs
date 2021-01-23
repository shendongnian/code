    public abstract class CursorReader
    {
        private int m_rowCount;//no longer read-only
        protected CursorReader()
        {
            //no virtual call here
        }
        protected abstract int CreateCursor(string sqlCmd);
        protected void Initialize()
        {
             //virtual call moved here
             m_rowCount = CreateCursor(sqlCmd); //virtual call !
        }
    }
    public class SqlCursorReader : CursorReader
    {
        private SqlConnection m_sqlConnection;
        
        public SqlCursorReader(string sqlCmd, SqlConnection sqlConnection)
        {
            m_sqlConnection = sqlConnection;
            
            //the derived classes NEED to call the base class' Initialize() 
            Initialize();
        }
        protected override int CreateCursor(string sqlCmd)
        {
            //uses not-yet-initialized member m_sqlConnection
            var cursor = new CustomCursor(sqlCmd, m_sqlConnection); 
            return cursor.Count();
        }
    }
