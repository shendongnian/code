    public static void Write(this BinaryWriter source, IEnumerable items)
    {
         foreach (dynamic item in items)
              source.Write(item); //runtime overload resolution! It works!
    }
