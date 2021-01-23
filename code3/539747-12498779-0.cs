    public class Item
    {
        Uri content;
        public Uri Content
        {
            get
            {
                return content;
            }
        }
        public Visibility Visible
        {
            get
            {
                if(content != null)
                    return Visibility.Visible;
            }
        }
    }
    <WebView Content="{Binding Content}" Visibility="{Binding Visible}" Margin="0,5,20,20"/>
