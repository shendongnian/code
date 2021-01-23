    string RollupException(Exception ex)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(ex.Message);
        while(ex.InnerException != null) 
        {
             sb.Append(Environment.Newline);
             sb.Append(ex.Message);
             ex = ex.InnerException;
        }
        return sb.ToString();
    }
