    private void InterceptResponse(IRequest request,
                                   IResponse response,
                                   object dto)
    {
        var localizedRequest = response.Dto as ILocalizedRequest;
        var localizedDto = dto as ILocalizedDto;
        if (localizedRequest != null
            && localizedDto != null)
        {
          Localizer.Translate(localizedDto,
                              localizedRequest.Language);
        }
    }
