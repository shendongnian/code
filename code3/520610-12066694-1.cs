    [ServiceContract]
    [ServiceKnownType(typeof(SqlParameter[]))]
    [ServiceKnownType(typeof(object))]
    [ServiceKnownType(typeof(SqlDbType))]
    [ServiceKnownType(typeof(ParameterDirection))]
    [ServiceKnownType(typeof(SqlDateTime))]
    public interface IServerService
    {
        [OperationContract]
        DataSet ExecuteDataSet(CommandType commandType, string commandText, SQLArray[] dsparams);
        [OperationContract]
        int ExecuteNonQuery(CommandType commandType, string commandText, SQLArray[] nonparams);
        
    }
    [DataContract]
    [KnownType(typeof(SqlParameter[]))] 
    [KnownType(typeof(object))]
    [KnownType(typeof(SqlDbType))]
    [KnownType(typeof(ParameterDirection))]
    [KnownType(typeof(SqlDateTime))]
    public class SQLArray
    {
      //  private SqlParameter[] array;
        private string paramaterName;
        private string paramaterValue;
        private ParameterDirection paramaterDirection;
        private SqlDbType paramatertype;
        
       [DataMember]
        public string ParamaterName
        {
            get { return paramaterName; }
            set { paramaterName = value; }
        }
        [DataMember]
        public string ParamaterValue
        {
            get { return paramaterValue; }
            set { paramaterValue = value; }
        }
        [DataMember]
        public ParameterDirection ParamaterDirection
        {
            get { return paramaterDirection; }
            set { paramaterDirection = value; }
        }
        [DataMember]
        public SqlDbType Paramatertype
        {
            get { return paramatertype; }
            set { paramatertype = value; }
        }
    }
