    public class WeekendObject : DynamicObject
    {
      Dictionary<string, object> propertybag = new Dictionary<string, object>();      
      public override bool TryGetMember(GetMemberBinder binder, out object result)
      {
        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
        {
          if (name.StartsWith("Sunday"))
          {
            return propertybag.TryGetValue(name, out result);
          }
        }
        else
        {
          if (!name.StartsWith("Sunday"))
          {
            return propertybag.TryGetValue(name, out result);
          }
        }
      }
      public override bool TrySetMember(SetMemberBinder binder, object value)
      {
        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
        {
          if (name.StartsWith("Sunday"))
          {
            propertybag[binder.Name.ToLower()] = value;
            return true;
          }
        }
        else
        {
          if (!name.StartsWith("Sunday"))
          {
            propertybag[binder.Name.ToLower()] = value;
            return true;
          }
        }
        return false;
      }
    }
