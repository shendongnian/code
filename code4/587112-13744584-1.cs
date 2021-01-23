         static  class Assets
        {
            public interface IAssetHandler<out T> 
            {
                T GetAsset(string name);
            }
    
            private static readonly Dictionary<Type,object> _handlers=new Dictionary<Type, object>();
    
            public static T GetAsset<T>(string name)
            {
    
                object assetHandler;
    
                if(!_handlers.TryGetValue(typeof(T),out assetHandler))
                {
                  throw  new Exception("No handler for that type of asset");
                }
    
                return (assetHandler as IAssetHandler<T>).GetAsset(name);
    
            }
    
    
            public static void RegisterAssetHandler<T>(IAssetHandler<T> handler)
            {
                _handlers[typeof (T)] = handler;
            }
    
        }
    
    
     public class IntAssetsHandler:Assets.IAssetHandler<int>
            {
                #region Implementation of IAssetHandler<out int>
    
                public int GetAsset(string name)
                {
                    return 0;
                }
    
                #endregion
            }
    
    
    
    
    
            static void Main(string[] args)
            {
                Assets.RegisterAssetHandler(new IntAssetsHandler());
    
                Console.WriteLine(Assets.GetAsset<int>("test"));
    
    
            }
