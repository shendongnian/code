    interface IFetchValue {
        string FetchValue(Control c);
    }
    class TextBoxFetcher: IFetchValue {
      public string FetchValue (Control c) {
         return ((TextBox)c).Value;
      }
    }
    class ComboBoxFetcher: IFetchValue {
      public string FetchValue (Control c) {
         return ((ComboBox)c).SelectedValue;
      }
    }
    // This could be initialized via reflection of all IFetchValue types
    // with a bit more work.
    IDictionary<Type, IFetchValue> map = new Dictionary<Type, IFetchValue> {
      { typeof(TextBox), new TextBoxFetcher() },
      { typeof(ComboBox), new ComboBoxFetcher() },
    };
    string GetValue(Control c) {
      IFetchValue fetcher;
      if (c != null && map.TryGetValue(c.GetType(), out fetcher)) {
        return fetcher(c);
      } else {
        throw new Exception("Whoops!");
      }
    }
