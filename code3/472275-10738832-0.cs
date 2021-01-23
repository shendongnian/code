    public interface IEnumBase
    {
      IEnumItem[] Items { get; }
    }
    
    public interface IEnumItem : IEnumBase
    {
      string DisplayText { get; }
    }
    
    public class EnumItem : IEnumItem
    {
      public string DisplayText { get; set; }
      public IEnumItem[] Items { get; set; }
    }
    
    public class EnmSections : IEnumBase
    {
      public IEnumItem[] Items { get; private set; }
    
      public EnmSections()
      {
        Items = new IEnumItem[]
        {
          new EnumItem
          {
            DisplayText = "Section1",
            Items = new IEnumItem[]
            {
              new EnumItem { DisplayText = "TestA" },
              new EnumItem { DisplayText = "TestB" }
            }
          },
          new EnumItem
          {
            DisplayText = "Section2",
            Items = new IEnumItem[]
            {
              new EnumItem { DisplayText = "Test1" },
              new EnumItem { DisplayText = "Test2" }
            }
          }
        };
      }
    }
