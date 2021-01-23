    class SearchViewModel
    {
       private readonly IDownloaderFactory _downloaderFactory;
       private readonly INewObject _newObject;
       public SearchViewModel(IDownloaderFactory downloaderFactory, INewObject newObject)
       {
           _downloaderFactory = downloaderFactory;
           _newObject = newObject;
           Console.WriteLine(downloaderFactory.Create().GetHashCode());
           Console.WriteLine(downloaderFactory.Create().GetHashCode());
       }
