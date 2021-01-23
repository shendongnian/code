    // Predicts whether the given type cannot be used as a type argument.
    public static bool IsNeverValidGenericArgument(this Type type)
    {
      if (type == null)
        throw new ArgumentNullException("type");
      // Pointer types and ByRef types.
      if (type.IsPointer || type.IsByRef)
        return true;
      // The following four special cases were found by reflecting through all types in mscorlib.dll, System.dll, and System.Core.dll.
      // The list may be different in other versions of the framework.
      var exceptions = new HashSet<Type>
      {
        typeof(ArgIterator), typeof(RuntimeArgumentHandle), typeof(TypedReference), typeof(void),
      };
      return exceptions.Contains(type);
    }
