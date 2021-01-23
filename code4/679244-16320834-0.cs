    public class AutoSelectingDataProvider : IDataProvider 
    {
        public AutoSelectingDataPovider(HttpDataProvider httpDataProvider, FallBackDataProvider fallBackProvider)
        {
            _httpDataProvider = httpDataProvider;
            _fallBackDataProvider = fallBackDataProvider;
        }
        public string GetData(int id)
        {
            try
            {
                return _httpDataProvider.GetData(id);
            }
            catch (Exception)
            {
                return _fallBackDataProvider.GetData(id);
            }
        return result;
        }
    }
    container.Register(
        Component.For<HttpDataProvider>(),
        Component.For<FallBackDataProvider>(),
        Component.For<IDataProvider>().ImplementedBy<FallBackDataProvider>());
