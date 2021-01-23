    public class EnumProvider
    {
       public enum ePriceType{
      Fixed = 1,
      Variable = 2
    }
    var a = Enum.GetName(typeof(EnumProvider.ePriceType), 1);
