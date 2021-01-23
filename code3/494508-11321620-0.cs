      var InitNetCellCache = InitNetCell();
                InitNetCellCache.Subscribe((s) =>
                {
                    Debug.WriteLine("init NetCell Cache OK.");
                    
                    //ScheduleCrrentThread(innerAction);
                });
                var InitKPIMapCache = InitKPIMapCell();
                var zipped = InitKPIMapCache.Zip(InitNetCellCache, (left, right) => left + " - " + right);
                zipped.Subscribe((s) =>
                    {
                        //When all async methods are completed
                        runtime.Show();
                    }
                );
      IObservable<object> InitNetCell()
        {
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            INetCellManager inc = unityContainer.Resolve<INetCellManager>();
            var NetCell = Observable.FromEvent<InitCacheCompletedDelegate, object>(
             h => ((object sendera) => h.Invoke(sendera)),
             h => inc.InitCacheCompleted += h,
             h => inc.InitCacheCompleted -= h);
             //Run you async method
            inc.InitCache();
            return from e in NetCell select e;
        }
