    public static class LoggerExtensions
    {
        public static void Error(this ILogger logger, string message, Exception exception)
        {
            if (exception is DbEntityValidationException dbException)
            {
                message += "\nValidation Errors: ";
                foreach (var error in dbException.EntityValidationErrors.SelectMany(entity => entity.ValidationErrors))
                {
                    message += $"\n * Field name: {error.PropertyName}, Error message: {error.ErrorMessage}";
                }
            }
    
            logger.LogError(default(EventId), exception, message);
        }
    }
