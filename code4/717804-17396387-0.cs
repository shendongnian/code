        m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType );
        foreach( var connectionString in System.Configuration.ConfigurationManager.ConnectionStrings )
        {
            string outString = connectionString.ToString();
            m_log.Debug( outString );
        }
