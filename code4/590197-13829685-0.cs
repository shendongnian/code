    if (Enum.GetUnderlyingType(e.GetType()) != typeof(int))
      throw new NotImplementedException();
    var list = new List<Enum>();
    for (int i = 1; i != 0; i <<= 1)
    {
      var eachEnum = (Enum)(Enum.ToObject(e.GetType(), i));
      if (e.HasFlag(eachEnum))
        list.Add(eachEnum);
    }
    return string.Join(" | ", list);
