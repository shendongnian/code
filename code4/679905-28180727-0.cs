    using Microsoft.SqlServer.Server;
    using System.Data.SqlTypes;
    using System.Collections;
    
    public class CachingStuff
    {
        private static readonly Hashtable _KeyValuePairs = new Hashtable();
    
        [SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = true)]
        public static SqlString GetKVP(SqlString KeyToGet)
        {
            if (_KeyValuePairs.ContainsKey(KeyToGet.Value))
            {
                return _KeyValuePairs[KeyToGet.Value].ToString();
            }
    
            return SqlString.Null;
        }
    
        [SqlProcedure]
        public static void SetKVP(SqlString KeyToSet, SqlString ValueToSet)
        {
            if (!_KeyValuePairs.ContainsKey(KeyToSet.Value))
            {
                _KeyValuePairs.Add(KeyToSet.Value, ValueToSet.Value);
            }
    
            return;
        }
    
        [SqlProcedure]
        public static void UnsetKVP(SqlString KeyToUnset)
        {
            _KeyValuePairs.Remove(KeyToUnset.Value);
            return;
        }
    }
