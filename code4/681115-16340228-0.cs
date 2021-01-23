    public class character {
      // A type that is convertible from int and has a Mod property
      public class Modder {
        //private variable to hold the integer value
        private int _value;
        // private constructor that is used by the converter
        private Modder(int value){ _value = value; }
        // implicit converter to handle the conversion from int
        public static implicit operator Modder(int value) {
          return new Modder(value);
        }
        // Property Mod that does the calculation
        public int Mod {
          get { return _value / 2; }
        }
      }
      public string Name, Owner;
      public int Con, Dex, Int, Wis, Cha, AC, Speed, maxHP, currHP, AP, SV, Surges;
      public Modder Str;
    }
