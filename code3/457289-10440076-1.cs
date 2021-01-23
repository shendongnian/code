    public partial class SimpleRequest : ISomeRequestClass
    {
      public string HeaderProp
      {
        get
        {
          return Header;
        }
        set
        {
          Header = value;
        }
      }
      public string Prop
      {
        get
        {
          return SimpleRequest1;
        }
        set
        {
          SimpleRequest1= value;
        }
      }
    }
