    public class LoadMoreTemplateSelector: DataTemplateSelector
    {
        public DataTemplate LoadMoreTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }
       
        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            if (item is LoadMoreViewModel)
            {
                return LoadMoreTemplate;
            }
            else
            {
               return DefaultTemplate;
            }
        }
    }
