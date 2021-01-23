    public async Task<XDocument> GetAllDataAsync()
    {
      var task1 = CallServiceAsync(1);
      var task2 = CallServiceAsync(2);
      var task3 = CallServiceAsync(3);
      ...
      XDocument[] results = await task.WhenAll(task1, task2, task3, ...);
      return JoinXmlDocuments(results);
    }
