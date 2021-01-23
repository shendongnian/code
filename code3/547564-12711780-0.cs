    public abstract class CursorReader
    {
        private int? m_rowCount;
        protected CursorReader()
        {
    
        }
        protected abstract int CreateCursor(string sqlCmd);
        protected int RowCount {
          get {
              if (m_RowCount == null)
              {
                 m_RowCount = CreateCursor(sql);
              }
              return m_RowCount.Value;
          }
    
        }
    }
