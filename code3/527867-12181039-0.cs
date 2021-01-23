    public async Task LoadMerchantsAndUpdateUiAsync()
    {
      LoadingMerchants = true;
      await LoadMerchantsAsync();
      LoadingMerchants = false;
    }
    public async Task<bool?> LoginAsync(string username, string password)
    {
      var uri = new Uri(string.Format("{0}/User/Login?userName={1}&password={2}", ServerURL, username, password));
      bool? result = await GetJsonAsync<bool?>(uri);
      if (result.HasValue && result.Value)
      {
        LoginDone = true;
        LoadMerchantsAndUpdateUiAsync();
      }
      return result; 
    }
