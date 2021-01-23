    var result = new ResponseResult<Person>();
    try
    {
      result.Data = db.FindPerson(id);
    }
    catch (SqlException ex)
    {
      var error = ResponseErrorBase();
      error.Code = 415;
      error.Message = "Sql Exception";
    }
    catch (Exception ex)
    {
      var error = InternalResponseError();
      error.InternalErrorLogID  = Log.WriteException(ex);
      error.Code = 500;
      error.Message = "Internal Error";
    }
    // MVC might look like:
    return this.Json(result);
