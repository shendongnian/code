    public static class MyUtilClass
    {
        public static string GetExceptionMsg(Exception ex)
        {
                    var exError = e.Message;
                    if ( e.InnerException != null ) {
                        exError += "<br>" + e.InnerException.Message;
                        if (e.InnerException.InnerException != null ) {
                            exError += "<br>" + e.InnerException.InnerException.Message;
                        }
                    }
            return exError;
        }
    }
