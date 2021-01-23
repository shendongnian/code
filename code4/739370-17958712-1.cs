    public IDbDataParameter CreateParameter(IDbCommand cmd, string name, DbType type) {
        OracleParameter p = (OracleParameter)cmd.CreateParameter();
        p.ParameterName = name;
        p.OracleDbType = DBTypeToOracle(type);
        if (p.OracleDbType == OracleDbType.TimeStampLTZ) {
            p.Precision = 3;
        }
        return p;
    }
