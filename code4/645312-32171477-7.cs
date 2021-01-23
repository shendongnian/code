    public class LocalizationFeature : IPlugin
    {
      public const string LanguageKey = "X-Language";
      public void Register(IAppHost appHost)
      {
        this.GlobalRequestFilters.Add(this.InterceptRequest);
        this.GlobalResponseFilters.Add(this.InterceptResponse);
      }
      private void InterceptRequest(IRequest request,
                                    IResponse response,
                                    object dto)
      {
        var localizedRequest = dto as ILocalizedRequest;
        if (localizedRequest != null)
        {
          request.SetItem(LanguageKey,
                          localizedRequest.Language);
        }
      }
      private void InterceptResponse(IRequest request,
                                     IResponse response,
                                     object dto)
      {
        var localizedDto = dto as ILocalizedDto;
        if (localizedDto != null)
        {
          var language = request.GetParam(LanguageKey) ?? request.GetItem(LanguageKey);
          if (!string.IsNullOrEmpty(language))
          {
            Localizer.Translate(localizedDto,
                                language);
          }
        }
      }
    }
