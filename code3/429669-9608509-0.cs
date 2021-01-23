    <ComboBox x:Name="CatalogName" ... SelectedItem="{Binding SelectedCatalog}" />
    public class ShellViewModel : PropertyChangedBase
    {
        public List<string> CatalogName
        {
            get
            {
                return new List<string> { "foo", "bar" };
            }
        }
        public string SelectedCatalog
        {
           get
           {
              return this.selectedCatalog;
           }
           set
           {
              this.selectedCatalog = value;
              this.NotifyOfPropertyChanged(() => this.SelectedCatalog);
           }
        }
