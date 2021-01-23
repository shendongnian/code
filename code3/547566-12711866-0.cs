    public abstract class CursorReader
    {
        private readonly int m_rowCount;
        protected CursorReader()
        {
        }
        protected void Init()
        {
             m_rowCount = CreateCursor(sqlCmd); //virtual call !
        }
    
        protected abstract int CreateCursor(string sqlCmd);
    }
