    // can also be made an extension method
    static bool HasCorrectInType(ICalculation calc, Type desiredInType)
    {
      var t = calc.GetType();
      do
      {
        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(CalculationBase<,>))
          return t.GetGenericArguments()[0].IsAssignableFrom(desiredInType);
        t = t.BaseType;
      } while (t != null)
      throw new Exception("The type " + calc.GetType() + " not supported");
    }
