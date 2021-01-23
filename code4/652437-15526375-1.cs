    // your enum
    public enum ItemType
    {
        Unknown = 0,
        //
        Physical = 1,
        //
        Logical = 2,
    }
    // your model
    public class ItemToSend
    {
        pubic ItemType m_ItemType { get; set; }
    }
    // in your action
    private static List<ItemType> BuildListItem(IEnumerable<ItemToSend> listItemToSend)
    {
        ...
          switch (item.m_ItemType)
          {
              case ItemType.Unknown:
                 itemToAdd.Type = AnotherEnumValue.Unknown;
                 break;
              case ItemType.Physical:
                 itemToAdd.Type = AnotherEnumValue.Physical;
                 break;
              case ItemType.Logical:
                 itemToAdd.Type = AnotherEnumValue.Logical;
                 break;
          } 
        ...
    }   
