    public static IEnumerable<string> GetFormattedErrorMessage(this Exception e)
            {
                if (e == null)
                {
                    throw new ArgumentNullException("e");
                }
    
                var exError = e.Message;
                if (e.InnerException != null)
                {
                    exError += "<br>" + e.InnerException.Message;
                    if (e.InnerException.InnerException != null)
                    {
                        exError += "<br>" + e.InnerException.InnerException.Message;
                    }
                }
    
                yield return exError;
            }
