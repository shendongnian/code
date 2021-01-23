    var aCar = Get("Car") as Car;
    public dynamic Get(string type)
    {
      return Activator.CreateInstance(Type.GetType(type));
    }
