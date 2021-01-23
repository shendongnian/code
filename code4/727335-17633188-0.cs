    public interface IParameterMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameterValues"></param>
        void AssignParameters(DbCommand command, object[] parameterValues);
    }
