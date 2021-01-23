    List<int> list = new List<int>(); // an empty List<T>
    Type type = list.GetType().GetProperty("Item").PropertyType; // System.Int32
    bool isEnum = type.IsEnum; // of course false
    List<DayOfWeek> days = new List<DayOfWeek>();
    type = days.GetType().GetProperty("Item").PropertyType;
    isEnum = type.IsEnum; // true
