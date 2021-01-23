    public sealed class SharedInt
    {
      private int _value;
      /// <summary>Creates a new SharedInt with a value of zero.</summary>
      public SharedInt(){}
      /// <summary>Creates a new SharedInt.</summary>
      /// <param name="value">The initial value of the object.</param>
      public SharedInt(int value)
      {
        _value = value;
      }
      /// <summary>Returns the value of the SharedInt.</summary>
      public int Value
      {
        get { return _value; }
      }
      /// <summary>Returns the value of the SharedInt.</summary>
      /// <param name="ri">The SharedInt to cast.</param>
      /// <returns>An integer of the same value as the SharedInt.</returns>
      public static implicit operator int(SharedInt ri)
      {
        return ri._value;
      }
      /// <summary>Atomically increment the value of the SharedInt by one.</summary>
      /// <returns>The new value.</returns>
      public int Increment()
      {
        return Interlocked.Increment(ref _value);
      }
      /// <summary>Atomically decrement the value of the SharedInt by one.</summary>
      /// <returns>The new value.</returns>
      public int Decrement()
      {
        return Interlocked.Decrement(ref _value);
      }
      /// <summary>Atomically add a value to the SharedInt.</summary>
      /// <param name="addend">The number to add to the SharedInt.</param>
      /// <returns>The new value.</returns>
      public int Add(int addend)
      {
        return Interlocked.Add(ref _value, addend);
      }
      /// <summary>Atomically replace the value of the SharedInt, returning the previous value.</summary>
      /// <param name="value">The number to set the SharedInt to.</param>
      /// <returns>The old value.</returns>
      public int Exchange(int value)
      {
        return Interlocked.Exchange(ref _value, value);
      }
      /// <summary>Atomically subtract a value from the SharedInt.</summary>
      /// <param name="subtrahend">The number to subtract from the SharedInt.</param>
      /// <returns>The new value.</returns>
      public int Subtract(int subtrahend)
      {
        return Interlocked.Add(ref _value, -subtrahend);
      }
    }
