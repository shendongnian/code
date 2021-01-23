    namespace App
    {
      class Program
      {
        static void Main(string[] args)
        {
          var val = new EnumWrapper(B.f);
          Enum en = val.EnumVal;
          Console.WriteLine("{0}.{1}",en.GetType().Name,en);
        }
      }
      enum EnumType { A, B }
      enum A { a, b, c = 34, d = 12 }
      enum B { a, b, e = 54, f = 56 }
      class EnumWrapper
      {
        public EnumWrapper(Enum i)
        {
          type = (EnumType) Enum.Parse( typeof(EnumType), i.GetType().Name );
          index = Convert.ToInt32(i);
        }
        public EnumType type;
        public int index;
        public Enum EnumVal {
          get {
            Enum c = (Enum)Enum.ToObject(
              Type.GetType(
                "App." + type
              ), index
            );
            return c;
          }
        }
      }
    }
