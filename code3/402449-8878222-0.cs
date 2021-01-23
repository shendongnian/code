public class EnumExtensions
  {
    public static IEnumerable<SelectListItem> GetEnumSelectList<T>()
    {
      return
        new SelectList(
          Enum.GetValues(typeof(T)).Cast<T>().Select(
            x =>
            new
            {
              Value = x.ToString(),
              Text = x.ToString()
            }).ToList(),
        "Value",
        "Text");
    }
  }
