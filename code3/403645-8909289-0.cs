    public sealed class Product
    {
      private String name;
      public String Name
      {
        get { return name; }
        set
        {
          if (value != null) name = value;
          else throw new UndefinedNameException();
        }
      }
      public sealed class UndefinedNameException : ApplicationException
      {
        public UndefinedNameException() : base("Name cannot be null") {}
      }
    } // end of class Product
