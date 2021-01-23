    public ObservableCollection<MyUrlWrapper> UrlsProperty
    {
        get;
        private set;
    }
    public class MyUrlWrapper
    {
        public string Url {get;set;}
        public Uri MyUri {get{return new Uri(this.Url);}}
    }
    <Hyperlink NavigateUri="{Binding Path=MyUri}" Click="EmailAsWWW_Click">
      <Run Text="{Binding Path=Url}" />
    </Hyperlink>
