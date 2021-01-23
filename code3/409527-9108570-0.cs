    using Apache.Cassandra;
    using Thrift.Protocol;
    using Thrift.Transport;
    
    namespace CassandraWebLibrary
    {
        public class MyDb
        {
            String _host;
            int _port;
            String _keyspace;
            bool _isConnected;
            TTransport _transport = null;
            Apache.Cassandra.Cassandra.Client _client = null;
            String columnFamily = "ColumnFamilyName";
            public VazhikaattiDB(String host, int port, String keyspace)
            {
                _host = host;
                _port = port;
                _keyspace = keyspace;
                _isConnected = false;
            }
    
            public bool Connect()
            {
                try
                {
                    _transport = new TFramedTransport(new TSocket(_host, _port));
                    TProtocol protocol = new TBinaryProtocol(_transport);
                    _client = new Apache.Cassandra.Cassandra.Client(protocol);
    
                    _transport.Open();
    
                    _client.set_keyspace(_keyspace);
    
                    _isConnected = true;
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                }
                return _isConnected;
            }
    
            public bool Close()
            {
                if (_transport.IsOpen)
                    _transport.Close();
                _isConnected = false;
                return true;
            }
    
            public bool InsertData(Send your data as parameters here)
            {
                try
                {
                    List<Column> list = new List<Column>();
                    string strKey = keyvalue;
    
                    #region Inserting into Coulmn family
    				 List<Byte> valbytes = new List<byte>(BitConverter.GetBytes(value)); //You might have to pad this with more bytes to make it length of 8 bytes
    
    				Column doublecolumn1 = new Column()
    				{
    					Name = Encoding.UTF8.GetBytes("column1"),
    					Timestamp = timestampvalue,
    					Value = valbytes.ToArray()
    				};
    				list.Add(doublecolumn1);
                    
                    Column stringcolumn2 = new Column()
                    {
                        Name = Encoding.UTF8.GetBytes("column2"),
                        Timestamp = timestampvalue,
                        Value = Encoding.UTF8.GetBytes("StringValue")
                    };
                    list.Add(stringcolumn2);
    
                    Column timecolumn3 = new Column()
                    {
                        Name = Encoding.UTF8.GetBytes("column3"),
                        Timestamp = timestampvalue,
                        Value = BitConverter.GetBytes(DateTime.Now.Ticks)
                    };
                    list.Add(timecolumn3);
    				#endregion
    
    
                    ColumnParent columnParent = new ColumnParent();
                    columnParent.Column_family = columnFamily;
    
                    Byte[] key = Encoding.UTF8.GetBytes(strKey);
                    foreach (Column column in list)
                    {
                        try
                        {
                            _client.insert(key, columnParent, column, ConsistencyLevel.QUORUM);
                        }
                        catch (Exception e)
                        {
                            log.Error(e.ToString());
                        }
                    }
    
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    return false;
                }
            }
    
            public List<YourReturnObject> GetData(parameters)
            {
                try
                {
                    ColumnParent columnParent = new ColumnParent();
                    columnParent.Column_family = columnFamily;
                    DateTime curdate = startdate;
    
                    IndexExpression indExprsecondkey = new IndexExpression();
                    indExprsecondkey.Column_name = Encoding.UTF8.GetBytes("column");
                    indExprsecondkey.Op = IndexOperator.EQ;
    
    				List<Byte> valbytes = PadLeftBytes((int)yourid, 8);
    				indExprsecondkey.Value = valbytes.ToArray();
    				indExprList.Add(indExprsecondkey);
                        
    
    				IndexClause indClause = new IndexClause()
    				{
    					Expressions = indExprList,
    					Count = 1000,
    					Start_key = Encoding.UTF8.GetBytes("")
    				};
    
    				SlicePredicate slice = new SlicePredicate()
    				{
    					Slice_range = new SliceRange()
    					{
    						//Start and Finish cannot be null 
    						Start = new byte[0],
    						Finish = new byte[0],
    						Count = 1000,
    						Reversed = false
    					}
    				};
    				List<KeySlice> keyslices = _client.get_indexed_slices(columnParent, indClause, slice, ConsistencyLevel.ONE);
    				foreach (KeySlice ks in keyslices)
    				{
    					String stringcolumnvalue = Encoding.UTF8.GetString(cl.Column.Value);
    					double doublevalue= (Double)BitConverter.ToDouble(cl.Column.Value); 
    					long timeticks = BitConverter.ToInt64(cl.Column.Value, 0);
    					DateTime dtcolumntime = new DateTime(timeticks);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                }
    
                return yourdatalist;
            }
    
           
        }
    }
