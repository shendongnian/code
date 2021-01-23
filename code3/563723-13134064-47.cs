    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    public class Db<T> : IDb where T : IDbConnection, new()
    {
        string _connectionString;
        public Db(string connectionString)
        {
            _connectionString = connectionString;
        }
        IEnumerable<S> Do<R, S>(string query, Action<IDbCommand> parameterizer, 
                                Func<IDbCommand, IEnumerable<R>> actor, 
                                Func<R, S> selector)
        {
            using (var conn = new T())
            {
                using (var cmd = conn.CreateCommand())
                {
                    if (parameterizer != null)
                        parameterizer(cmd);
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    foreach (var item in actor(cmd))
                        yield return selector(item);
                }
            }
        }
        public int Add(string query, Action<IDbCommand> parameterizer)
        {
            return Do(query, parameterizer, cmd => ExecuteScalar(cmd), 
                      id => Convert.ToInt32(id)).First();
        }
        
        static IEnumerable<object> ExecuteScalar(IDbCommand cmd)
        {
            yield return cmd.ExecuteScalar();
        }
        public int Save(string query, Action<IDbCommand> parameterizer)
        {
            return Do(query, parameterizer, cmd => ExecuteNonQuery(cmd), 
                      noAffected => noAffected).First();
        }
        static IEnumerable<int> ExecuteNonQuery(IDbCommand cmd)
        {
            yield return cmd.ExecuteNonQuery();
        }
        public int SaveSafely(string query, Action<IDbCommand> parameterizer)
        {
            return Do(query, parameterizer, cmd => 
            {
                using (cmd.Transaction = cmd.Connection.BeginTransaction())
                {
                    var noAffected = ExecuteNonQuery(cmd);
                    cmd.Transaction.Commit();
                    return noAffected;
                }
            }, noAffected => noAffected).First();
        }
        public IEnumerable<S> Get<S>(string query, Action<IDbCommand> parameterizer, 
                                     Func<IDataRecord, S> selector)
        {
            return Do(query, parameterizer, cmd => ExecuteReader(cmd), selector);
        }
        static IEnumerable<IDataRecord> ExecuteReader(IDbCommand cmd)
        {
            using (var r = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                while (r.Read())
                    yield return r;
        }
    }
