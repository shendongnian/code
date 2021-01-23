    using System;
    using System.Collections.Generic;
    class ContentDetails
    {
      // Maps id to RefValue.
      private static readonly Dictionary<string, string> idValueDictionary =
        new Dictionary<string,string>()
        {
          { "00", "14" },
          { "01", "18" },
          { "XX", "00" }
        };
      // Maps RefValue to ViewName
      private static readonly Dictionary<string, string> valueNameDictionary =
        new Dictionary<string,string>()
        {
          { "00", "Menu" },
          { "14", "Menu" },
          { "18", "Topic" }
        };
      // Private constructor. Use GetContentDetails factory method.
      private ContentDetails(string refValue, string viewName)
      {
        this.RefValue = refValue;
        this.ViewName = viewName;
      }
      // Gets the RefValue.
      public string RefValue
      {
        get;
        private set;
      }
      // Gets the ViewName.
      public string ViewName
      {
        get;
        private set;
      }
      // Creates a new ContentDetails from the specified id.
      public static ContentDetails GetContentDetails(string id)
      {
        // Extract key from id.
        string key = id.Substring(2,2);
      
        // If key not in dictionary, use the default key "XX".
        if (!idValueDictionary.ContainsKey(key))
        {
          key = "XX";
        }
        // Get refValue and viewName from dictionaries.
        string refValue = idValueDictionary[key];
        string viewName = valueNameDictionary[refValue];
        // Return a new ContentDetails object with properties initialized.
        return new ContentDetails(refValue, viewName);
      }
    }
