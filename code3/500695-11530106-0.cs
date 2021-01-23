    public class UserAdoNetAppenderParameter : AdoNetAppenderParameter
    {        
        public override void FormatValue(IDbCommand command, LoggingEvent loggingEvent)
        {            
            string[] data = loggingEvent.RenderedMessage.Split('~');
            string username = string.Empty;
            if (data != null && data.Length >= 1)
                username = data[0];
            
            // Lookup the parameter
            IDbDataParameter param = (IDbDataParameter)command.Parameters[ParameterName];
            // Format the value
            object formattedValue = username;
            // If the value is null then convert to a DBNull
            if (formattedValue == null)
            {
                formattedValue = DBNull.Value;
            }
            param.Value = formattedValue;
        }
    }
