            var container = new UnityContainer();
            container.RegisterType<IDownloader, Downloader>();
            container.RegisterType<INewObject, NewObject>();
            container.RegisterType<IDownloaderFactory, DownloaderFactory>();
            container.RegisterType<SearchViewModel>();
            container.RegisterInstance(container);
            var model = container.Resolve<SearchViewModel>();
