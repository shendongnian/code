     public class DownloaderFactory : IDownloaderFactory
     {
         private UnityContainer _Container;
         public DownloaderFactory(UnityContainer container)
         {
             this._Container = container;
         }
         public IDownloader Create()
         {
             return this._Container.Resolve<IDownloader>();
         }
     }
