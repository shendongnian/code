    public void Load(){
        BindDependencies<IDataReader<IList<Price>>, PricesDataReader
          , IDataConnection<IList<PricesCsvRecord>>, PricesXLConnection
          , DefaultDirectoryBuilder>
          ("ValDatePrices");
        BindDependencies<IDataReader<IList<Price>>, PricesDataReader
          , IDataConnection<IList<PricesCsvRecord>>, PricesXLConnection
          , DefaultDirectoryBuilder>
          ("EDDatePrices");
           // etc etc 
    }
     public void BindDependencies<
         TReaderBase, TReaderImpl,
         TDataConnectionBase, TDataConnectionImpl,
         TDirectoryBuilderFactoryImpl>
         (string baseName)
             where TReaderImpl : TReaderBase
             where TDataConnectionImpl : TDataConnectionBase
     {
         DirectoryBuilderInfo dirInfor = GetSettings(baseName);
     
         Bind<TReaderBase>()
               .To(typeof(TReaderImpl))
               .Named(baseName);
         Bind<TDataConnectionBase>().To(typeof(TDataConnectionImpl))
                .WhenParentNamed(baseName)
                .Named(baseName + "XLConnection");
         Func<IDirectoryBuilder> directoryBuilder = CreateDirectoryBuilderFunc<TDirectoryBuilderFactoryImpl>(dirInfor);
         Bind<IDirectoryBuilder>()
                .ToMethod(d => directoryBuilder())
                .WhenParentNamed(baseName + "XLConnection");
        }
    private Func<IDirectoryBuilder> CreateDirectoryBuilderFunc<TDirectoryBuilderFactoryImpl>(DirectoryBuilderInfo dirInfor)
    {
        Func<IDirectoryBuilder> directoryBuilder = 
             () => CreateDefaultDirectoryBuilder(dirInfor.BaseDirectory, dirInfor.FileName);
        if (typeof(TDirectoryBuilderFactoryImpl) == typeof(RiskDirectoryBuilderFactory))
        {
            directoryBuilder = 
             () => CreateRiskDirectoryBuilder(ValuationDate, dirInfor.BaseDirectory, dirInfor.FileName);
        }
        return directoryBuilder;
    }
    private DirectoryBuilderInfo GetSettings(string baseName)
    {
        var settingsName = baseName.ToUpperInvariant();
        return new DirectoryBuilderInfo()
        {
            BaseDirectory = ConfigurationManager.AppSettings[settingsName + "_DIR"],
            FileName = ConfigurationManager.AppSettings[settingsName + "_FILENAME"]
         };
     }
