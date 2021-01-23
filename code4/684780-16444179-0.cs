    public static SelectList ToSelectList(this Enum enumval)
    {
      var values = from Enum e in Enum.GetValues(enumval.GetType()) select new { ID = e, Name = e.GetDescription() };
      SelectList list = new SelectList(values, "ID", "Name", enumval);
      return list;
    }
    public static string GetDescription(this Enum enumval)
    {
      //Some reflection that fetches the [Description] attribute, or returns enumval.ToString() if it isn't defined.
    }
