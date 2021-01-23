    public static Task<Company> LoadCompanyInfoAsync(Guid session)
    {
      var client = new QualerServiceClient("QualerService");
      return client.GetCompanyInfoAsync(session);
    }
    public async void ButtonClickOrWhatever(...)
    {
      var company = await LoadCompanyInfoAsync(mySession);
      // Update UI with company info.
    }
