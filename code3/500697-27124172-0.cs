    public class CustomAdoNetAppenderParameter : AdoNetAppenderParameter
    {
        public override void FormatValue(IDbCommand command, LoggingEvent loggingEvent)
        {
            // Try to get property value
            object propertyValue = null;
            var propertyName = ParameterName.Replace("@", "");
            var messageObject = loggingEvent.MessageObject;
            if (messageObject != null)
            {
                var property = messageObject.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    propertyValue = property.GetValue(messageObject, null);
                }
            }
            // Insert property value (or db null) into parameter
            var dataParameter = (IDbDataParameter)command.Parameters[ParameterName];
            dataParameter.Value = propertyValue ?? DBNull.Value;
        }
    }
