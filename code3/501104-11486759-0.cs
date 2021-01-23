    builder
        .Register(c => {
            try
            {
                return new InformationRetriever();
            }
            catch (Exception)
            {
                return new FailoverInformationRetreiver();
            }})
        .As<IInformationRetriever>();
