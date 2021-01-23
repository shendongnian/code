     public static void LogError(Exception ex)
            {
                var errMsg = ex.Message;
                errMsg += ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                //TODO: Do what you want if an error occurs
            }
