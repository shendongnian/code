    public static object CreateErrorResponse(object request, ValidationErrorResult validationError)
    {
      ResponseStatus responseStatus = DtoUtils.ToResponseStatus(validationError);
      return DtoUtils.CreateErrorResponse(request, (Exception) new ValidationError(validationError), responseStatus);
    }
    public static object CreateErrorResponse(object request, Exception ex, ResponseStatus responseStatus)
    {
      object responseDto = DtoUtils.CreateResponseDto(request, responseStatus);
      IHttpError httpError = ex as IHttpError;
      if (httpError != null)
      {
        if (responseDto != null)
          httpError.Response = responseDto;
        return (object) httpError;
      }
      else
      {
        string errorCode = ex.GetType().Name;
        string errorMessage = ex.Message;
        if (responseStatus != null)
        {
          errorCode = responseStatus.ErrorCode ?? errorCode;
          errorMessage = responseStatus.Message ?? errorMessage;
        }
        return (object) new HttpError(responseDto, HttpRequestExtensions.ToStatusCode(ex), errorCode, errorMessage);
      }
    }
