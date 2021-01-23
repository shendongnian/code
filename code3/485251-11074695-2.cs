    public class ResultItem : ICloneable
    {
      public object Clone()
      {
        var item = new ResultItem
                     {
                       ID = ID,
                       Name = Name,
                       isLegit = isLegit
                     };
        return item;
      }
    }
