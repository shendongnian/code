    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using MySql.Data.MySqlClient;
    
    namespace MySqlTest
    {
        public class ConnectedMySqlDataReader : DbDataReader
        {
            private readonly MySqlConnection _connection;
            private readonly Lazy<MySqlDataReader> _reader;
            private MySqlCommand _command;
            
    
            public ConnectedMySqlDataReader(MySqlConnection connection, string query)
            {
                if(connection == null)
                    throw new ArgumentNullException("connection");
                _connection = connection;
                _reader = new Lazy<MySqlDataReader>(() =>
                {                
                    _connection.Open();
                    _command = new MySqlCommand(query, _connection);
                    return _command.ExecuteReader();
                });
            }
    
            public ConnectedMySqlDataReader(string connectionString, string query)
                : this(new MySqlConnection(connectionString), query) { }
    
            private MySqlDataReader Reader
            {
                get { return _reader.Value; }
            }
    
            public override void Close()
            {
                if (_reader.IsValueCreated)            
                    _reader.Value.Close();
                if(_command != null)
                    _command.Dispose();
                _connection.Dispose();
            }
    
            public override DataTable GetSchemaTable()
            {
                return this.Reader.GetSchemaTable();
            }
    
            public override bool NextResult()
            {
                return this.Reader.NextResult();
            }
    
            public override bool Read()
            {
                return this.Reader.Read();
            }
    
            public override int Depth
            {
                get { return this.Reader.Depth; }
            }
    
            public override bool IsClosed
            {
                get { return this.Reader.IsClosed; }
            }
    
            public override int RecordsAffected
            {
                get { return this.Reader.RecordsAffected; }
            }
    
            public override bool GetBoolean(int ordinal)
            {
                return this.Reader.GetBoolean(ordinal);
            }
    
            public override byte GetByte(int ordinal)
            {
                return this.Reader.GetByte(ordinal);
            }
    
            public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
            {
                return this.Reader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
            }
    
            public override char GetChar(int ordinal)
            {
                return this.Reader.GetChar(ordinal);
            }
    
            public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
            {
                return this.Reader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
            }
    
            public override Guid GetGuid(int ordinal)
            {
                return this.Reader.GetGuid(ordinal);
            }
    
            public override short GetInt16(int ordinal)
            {
                return this.Reader.GetInt16(ordinal);
            }
    
            public override int GetInt32(int ordinal)
            {
                return this.Reader.GetInt32(ordinal);
            }
    
            public override long GetInt64(int ordinal)
            {
                return this.Reader.GetInt64(ordinal);
            }
    
            public override DateTime GetDateTime(int ordinal)
            {
                return this.Reader.GetDateTime(ordinal);
            }
    
            public override string GetString(int ordinal)
            {
                return this.Reader.GetString(ordinal);
            }
    
            public override object GetValue(int ordinal)
            {
                return this.Reader.GetValue(ordinal);
            }
    
            public override int GetValues(object[] values)
            {
                return this.Reader.GetValues(values);
            }
    
            public override bool IsDBNull(int ordinal)
            {
                return this.Reader.IsDBNull(ordinal);
            }
    
            public override int FieldCount
            {
                get { return this.Reader.FieldCount; }
            }
    
            public override object this[int ordinal]
            {
                get { return this.Reader[ordinal]; }
            }
    
            public override object this[string name]
            {
                get { return this.Reader[name]; }
            }
    
            public override bool HasRows
            {
                get { return this.Reader.HasRows; }
            }
    
            public override decimal GetDecimal(int ordinal)
            {
                return this.Reader.GetDecimal(ordinal);
            }
    
            public override double GetDouble(int ordinal)
            {
                return this.Reader.GetDouble(ordinal);
            }
    
            public override float GetFloat(int ordinal)
            {
                return this.Reader.GetFloat(ordinal);
            }
    
            public override string GetName(int ordinal)
            {
                return this.Reader.GetName(ordinal);
            }
    
            public override int GetOrdinal(string name)
            {
                return this.Reader.GetOrdinal(name);
            }
    
            public override string GetDataTypeName(int ordinal)
            {
                return this.Reader.GetDataTypeName(ordinal);
            }
    
            public override Type GetFieldType(int ordinal)
            {
                return this.Reader.GetFieldType(ordinal);
            }
    
            public override IEnumerator GetEnumerator()
            {
                return this.Reader.GetEnumerator();
            }
        }
    }
