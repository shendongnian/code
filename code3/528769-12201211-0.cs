    public class ComparisonManager<T>
    {
        private readonly T _diskServiceVm;
        private readonly T _panelServiceVm;
        public ComparisonManager(T diskServiceVm, T panelServiceVm)
        {
            _diskServiceVm = diskServiceVm;
            _panelServiceVm = panelServiceVm;
        }
    }
