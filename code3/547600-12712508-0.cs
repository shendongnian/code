    // should be in a static helper class
    public static string NameForSort(this MyObjectModel obj)
    {
      if (!string.IsNullOrEmpty(obj.LastName)) return obj.LastName;
      return obj.FirstLastName.Split(... // your splitting logic goes here
    }
    var ids = objects.OrderBy(o => o.NameForSort()).Select(o => o.ObjectID).ToList();
