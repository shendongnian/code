    public interface ICommonDataService
    {
         Dictionary<Type,Func<BaseItem, BaseItemViewModel>> GetMaps();
    }
    public class CommonDataService : ICommonDataService
    {
        public Dictionary<Type,Func<BaseItem, BaseItemViewModel>> GetMaps()
        {
             //Implementation
        }
    }
