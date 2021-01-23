    internal static async Task<BaseData> GetBaseDataAsync() {
      var catTask = GetParentCategoriesAsync();
      var yearTask = GetYearsAsync();
      await Task.WhenAll(catTask, yearTask).ConfigureAwait(false);
      var bdata = new BaseData {
        years = await yearTask,
        cats = await catTask
      };
      return bdata;
    }
    internal static async Task<List<APICategory>> GetParentCategoriesAsync() {
      try {
        var client = new HttpClient();
        string url = getAPIPath();
        url += "GetFullParentCategories";
        url += "?dataType=JSON";
        Uri targeturi = new Uri(url);
        List<APICategory> cats = new List<APICategory>();
        var cat_json = await client.GetStringAsync(targeturi).ConfigureAwait(false);
        cats = JsonConvert.DeserializeObject<List<APICategory>>(cat_json);
        return cats;
      } catch (Exception) {
        return new List<APICategory>();
      }
    }
    internal static async Task<List<double>> GetYearsAsync() {
      var client = new HttpClient();
      Uri targeturi = new Uri(getAPIPath() + "getyear?dataType=JSON");
      var year_json = await client.GetStringAsync(targeturi).ConfigureAwait(false);
      List<double> years = JsonConvert.DeserializeObject<List<double>>(year_json);
      return years;
    }
