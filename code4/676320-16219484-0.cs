    public static void AddDateTimeParameterToAppender(AdoNetAppender appender, string paramName)
    {
        var param = new AdoNetAppenderParameter
        {
            ParameterName = paramName, 
            DbType = System.Data.DbType.DateTime,
            Layout = new RawTimeStampLayout()
        };
        appender.AddParameter(param);
    }
