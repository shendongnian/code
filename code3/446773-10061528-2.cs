    private class ContentDetails {
      public string ViewName { get; private set; }
      public string RefValue { get; private set; }
      public ContentDetails(string name, value) {
        ViewName = name;
        RefValue = value;
      }
    }
    private ContentDetails getContentDetails(string id) {
      switch (id.Substring(2, 2)) {
        case "00": return new ContentDetails("Menu", "14");
        case "01": return new ContentDetails("Topic", "18");
        default: return new ContentDetails("Menu", "00");
      }
    }
