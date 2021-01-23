    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = (context) =>
                    {
                        var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => new ErrorModel()
                       {
                           ErrorCode = ((int)HttpStatusCode.BadRequest).ToString(CultureInfo.CurrentCulture),
                            ErrorMessage = p.ErrorMessage,
                            ServerErrorMessage = string.Empty
                        })).ToList();
                        var result = new BaseResponse
                        {
                            Error = errors,
                            ResponseCode = (int)HttpStatusCode.BadRequest,
                            ResponseMessage = ResponseMessageConstants.VALIDATIONFAIL,
                        };
                        return new BadRequestObjectResult(result);
                    };
               });
