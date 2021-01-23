    public override void Configure(Container container)
    {
        Plugins.Add(new ValidationFeature { 
            ErrorResponseFilter = CustomValidationError });
        container.RegisterValidators(typeof(MyValidator).Assembly);           
    }
    public static object CustomValidationError(
        ValidationResult validationResult, object errorDto)
    {
        var firstError = validationResult.Errors[0];
        var dto = new MyCustomErrorDto { 
            code = firstError.ErrorCode, error = firstError.ErrorMessage };
        //Ensure HTTP Clients recognize this as an HTTP Error
        return new HttpError(dto, HttpStatusCode.BadRequest, dto.code, dto.error);
    }
