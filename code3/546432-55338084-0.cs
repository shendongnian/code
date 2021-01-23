    catch (Exception ex)
    {   
        Response.Clear();
        Response.Write(HttpUtility.JavaScriptStringEncode(
            serializer.Serialize(new
            {
                Message = ex.Message,
                ExceptionType = ex.GetType().ToString(),
                StackTrace = ex.StackTrace
            }
        )));
    }
