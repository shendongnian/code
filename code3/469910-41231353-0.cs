    var field = typeof(System.Net.Http.Headers.HttpRequestHeaders)
      .GetField("invalidHeaders", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
    if (field != null)
    {
      var invalidFields = (HashSet<string>)field.GetValue(null);
      invalidFields.Remove("Content-Type");
    }
    _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "text/xml");
