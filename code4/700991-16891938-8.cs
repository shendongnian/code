    public class HorizontalGrid : DataGrid
    {
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            foreach (var seed in Columns.OfType<SeedColumn>().ToList())
            { 
                var seedColumnIndex = Columns.IndexOf(seed) + 1;
                var collectionName = seed.CollectionName;
                var headers = seed.Headers;
                // Check if ItemsSource is IEnumerable<object>
                var data = ItemsSource as IEnumerable<object>;
                if (data == null) return;
                // Copy to list to allow for multiple iterations
                var dataList = data.ToList();
                var collections = dataList.Select(d => GetCollection(collectionName, d));
                var maxItems = collections.Max(c => c.Count());
                for (var i = 0; i < maxItems; i++)
                {
                    var header = GetHeader(headers, i);
                    var columnBinding = new Binding(string.Format("{0}[{1}]" , seed.CollectionName , i));
                    Columns.Insert(seedColumnIndex + i, new DataGridTextColumn {Binding = columnBinding, Header = header});
                }
            }
        }
        private static string GetHeader(IList<string> headerList, int index)
        {
            var listIndex = index % headerList.Count;
            return headerList[listIndex];
        }
        private static IEnumerable<object> GetCollection(string collectionName, object collectionHolder)
        {
            // Reflect the property which holds the collection
            var propertyInfo = collectionHolder.GetType().GetProperty(collectionName);
            // Get the property value of the property on the collection holder
            var propertyValue = propertyInfo.GetValue(collectionHolder, null);
            // Cast the value
            var collection = propertyValue as IEnumerable<object>;
            return collection;
        }
    }
    public class SeedColumn : DataGridTextColumn
    {
        public static readonly DependencyProperty CollectionNameProperty =
            DependencyProperty.Register("CollectionName", typeof (string), typeof (SeedColumn), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty HeadersProperty =
            DependencyProperty.Register("Headers", typeof (List<string>), typeof (SeedColumn), new PropertyMetadata(default(List<string>)));
        public List<string> Headers
        {
            get { return (List<string>) GetValue(HeadersProperty); }
            set { SetValue(HeadersProperty, value); }
        }
        public string CollectionName
        {
            get { return (string) GetValue(CollectionNameProperty); }
            set { SetValue(CollectionNameProperty, value); }
        }
        public SeedColumn()
        {
            Headers = new List<string>();
        }
    }
