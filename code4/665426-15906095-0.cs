    public static async Task SearchAndPrintAsync(IWebSearcher webSearcher, string query)
    {
      var result = await webSearcher.SearchAsync(query);
      using (var enumerator = result.GetEnumerator())
      {
        if (enumerator.MoveNext())
          Console.WriteLine(enumerator.Current.Title);
        else
          Console.WriteLine("<none>");
      }
    }
