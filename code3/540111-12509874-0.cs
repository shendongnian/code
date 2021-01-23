    class ClassContainingYourProperty<T> where T : struct, IFormattable, IComparable<T>, IEquatable<T>
    {
      static ClassContainingYourProperty() // do type check in static constructor
      {
        var t = typeof(T);
        if (t != typeof(long) && t != typeof(Guid))
          throw new NotSupportedException("T cannot be " + t);
      }
      public virtual T YourProperty { get; set; }
    }
