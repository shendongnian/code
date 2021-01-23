    public UserError DoStuff()
    {
     try
     {
      // some web code
      // some sql code
     }
     catch (WebException webEx)
     {
       if (webEx.Message.Contains("SSL"))
       {
         return new UserError { Type = ErrorType.SSL };
       }
       
       return new UserError { Type = ErrorType.Web };
     }
     catch (SqlException sqlEx)
     {
        return new UserError { Type = ErrorType.SQL };
     }
    }
