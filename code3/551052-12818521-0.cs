    public class PostTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PostTemplate { get; set; }
        public DataTemplate SelectedPostTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            //ListViewItem lvi = item as ListViewItem;
            //AppNetClient.PostClass key = lvi.DataContext as AppNetClient.PostClass;
            AppNetClient.PostClass key = item as AppNetClient.PostClass;
            if (key.postTemplate == "Post")
            {
                return PostTemplate;
            }
            else
            {
                return SelectedPostTemplate;
            }
        }
    }
