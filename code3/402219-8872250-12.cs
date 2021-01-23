    public interface IDbProvider : IDisposable
    {
        void Open();
        void BeginTransaction();
        IDataReader ExecuteReader(string query);
        int ExecuteNonReader(string query);
        int GetLastInsertId();
        void Commit();
        void Rollback();
        void Close();
    }
