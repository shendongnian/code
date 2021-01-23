    public void RequestFilter(IHttpRequest req, IHttpResponse res, object requestDto)
    {
      IValidator validator = ValidatorCache.GetValidator(req, requestDto.GetType());
      if (validator == null)
        return;
      IRequiresHttpRequest requiresHttpRequest = validator as IRequiresHttpRequest;
      if (requiresHttpRequest != null)
        requiresHttpRequest.HttpRequest = req;
      string httpMethod = req.HttpMethod;
      ValidationResult result = validator.Validate(new ValidationContext(requestDto, (PropertyChain) null, (IValidatorSelector) new MultiRuleSetValidatorSelector(new string[1]
      {
        httpMethod
      })));
      if (result.IsValid)
        return;
      object errorResponse = DtoUtils.CreateErrorResponse(requestDto, ValidationResultExtensions.ToErrorResult(result));
      ServiceStack.WebHost.Endpoints.Extensions.HttpResponseExtensions.WriteToResponse(res, req, errorResponse);
    }
