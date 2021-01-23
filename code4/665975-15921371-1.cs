    public class StockItemEditViewModelFactory : IPartImportsSatisfiedNotification
    {
        private Dictionary<Type, IStockItemEditViewModelResolver> resolvers;
        [ImportMany(IStockItemEditViewModelResolver)]
        private IEnumerable<IStockItemEditViewModelResolver> importedResolvers;
        public void OnImportsSatisfied()
        {
            // Build dictionary of StockItem -> StockItemEditViewModel
            // Do error handling if no imported resolvers or duplicate types
            resolvers = new Dictionary<Type, IStockItemEditViewModelResolver>
            foreach(var importedResolver in importedResolvers)
            {
               resolvers.Add(importedResolver.StockItemType, importedResolver);
            }
        }
        public IStockItemEditViewModel Create(StockItem stockItem)
        {
            // Find the appropriate resolver based on stockItem.GetType(), handle errors
            var type = stockItem.GetType();
            var entry = this.resolvers.FirstOrDefault(kv => kv.Key == type);
            var resolver = entry.Value;
            return resolver.CreateEditViewModel(stockItem);
        }
    }
    [InheritedExport]
    public interface IStockItemEditViewModelResolver
    { 
        Type StockItemType { get; } 
        IStockItemEditViewModel CreateEditViewModel(StockItem stockItem);                 
    }
    public class LotItemEditViewModelResolver : IStockItemEditViewModelResolver
    {
        Type StockItemType { get { return typeof(LotItem); } }
 
        IStockItemEditViewModel CreateEditViewModel(StockItem stockItem)
        {
            return new LotItemEditViewModel(stockItem);
        }
    }
    public class MainViewModel
    {
        public IStockItemEditViewModel ActiveItem { get; private set; }
        public MainViewModel(StockItemEditViewModelFactory editViewModelfactory)
        {
            StockItem stockItem = new LotItem();
            this.ActiveItem = editViewModelFactory.Create(myStockItem);
        }
    }
