    public static class RowExtensionMethods
    {
      public static Worksheet GetWorksheet(this Row r)
      {
        if (r.Parent == null)
        {
          throw new InvalidOperationException("Row does not belong to sheetdata.");
        }
        if (r.Parent.Parent == null)
        {
          throw new InvalidOperationException("Row does not belong to worksheet.");
        }
        return (Worksheet)r.Parent.Parent;
      }
    }
    // Then in your method use the extension method like so
    public void YourMethod(Row r)
    {
      Worksheet w = r.GetWorksheet();
      // Do something with the worksheet...
    }
