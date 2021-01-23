    public class HorizontalGrid : DataGrid
    {
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            foreach (var seed in Columns.OfType<SeedColumn>().ToList())
            {
                var data = ItemsSource as IEnumerable<object>;
                if (data == null) return;
                var dataList = data.ToList();
                var collectionItems = ((IEnumerable<object>)dataList[0].GetType().GetProperty(seed.CollectionName).GetValue(dataList[0])).ToList();
                
                var seedColumnIndex = Columns.IndexOf(seed) + 1;
                for (var i = 0; i < collectionItems.Count; i++)
                {
                    var columnBinding = new Binding(string.Format("{0}[{1}]" , seed.CollectionName , i));
                    Columns.Insert(seedColumnIndex + i, new DataGridTextColumn {Binding = columnBinding});
                }
            }
        }
    }
    public class SeedColumn : DataGridTextColumn
    {
        public static readonly DependencyProperty CollectionNameProperty =
            DependencyProperty.Register("CollectionName", typeof (string), typeof (SeedColumn), new PropertyMetadata(default(string)));
        public string CollectionName
        {
            get { return (string) GetValue(CollectionNameProperty); }
            set { SetValue(CollectionNameProperty, value); }
        }
    }
