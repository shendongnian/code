    public static List<string> Search(string prefixText, int count)
    {
      var items = new List<string>();
      // ...
      items.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(
              text,
              imagePath));
      // ...
      
      return items;
    }
