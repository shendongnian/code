    [Serializable]
    public class ServerService : IServerService
    {
        #region Class Members
      // private ServerDataAccess dataAccess;
        SqlConnection connection = new SqlConnection("Data Source=LAPI;Initial Catalog=PrimierData;Integrated Security=True");
       // SqlDataReader dataReader;
        SqlCommand command;
       // SqlTransaction transaction = null;
       // SqlParameter[] parameters = null;
        #endregion
        #region Constructor
       public ServerService()
        {
        
        }
        public SqlParameter[] ArrayToSQL(SQLArray[] parama)
        {
           // bool outahere = false;
            int count = 0;
            foreach (SQLArray array in parama)
                count++;
            SqlParameter[] unner = new SqlParameter[count];
            for (int i = 0; i < count; i++)
            {
                unner[i] = new SqlParameter();
                unner[i].ParameterName = parama[i].ParamaterName;
                unner[i].SqlDbType = parama[i].Paramatertype;
                unner[i].Direction = parama[i].ParamaterDirection;
                unner[i].Value = parama[i].ParamaterValue;
            }
            return unner;
        }
        public SQLArray[] SQLtoArray(SqlParameter[] parama)
        {
            int count = 0;
            foreach (SqlParameter parameter in parama)
                count++;
            SQLArray[] unner = new SQLArray[count];
            for (int i = 0; i < parama.Count(); i++)
            {
                unner[i] = new SQLArray();
                unner[i].ParamaterName = parama[i].ParameterName;
                unner[i].Paramatertype = parama[i].SqlDbType;
                unner[i].ParamaterDirection = parama[i].Direction;
                unner[i].ParamaterValue = parama[i].Value.ToString();
            }
            return unner;
        }
        #endregion
        public void Open()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }
        public void Close()
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
        #region Methods
        /// <summary>
        /// Executes the non query. For Insert, Update and Delete
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText, SQLArray[] nonparams)
        {
           Open();
            command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            command.Parameters.AddRange(ArrayToSQL(nonparams));
            int returnValue = command.ExecuteNonQuery();
            command.Parameters.Clear();
            Close();
            return returnValue;
        }
        public DataSet ExecuteDataSet(CommandType commandType, string commandText, SQLArray[] dsparams)
        {
            
                Open();
                command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (dsparams != null)
                {
                    command.Parameters.AddRange(ArrayToSQL(dsparams));
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                command.Parameters.Clear();
                Close();
                return dataSet;
            
            
            
        }
 
