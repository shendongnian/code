    class ConstantValueUserType : IUserType
    {
        NullSafeGet(IDataReader rd, string[] names, object owner)
        {
            return 5; // Constant Value
        }
    
        public object NullSafeSet(ICommand cmd, object value, int index)
        {
            // empty, we dont want to write
        }
        public SqlType[] SqlTypes { get { return new SqlType[0]; } }
    }
