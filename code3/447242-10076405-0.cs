    //MainPage.xaml
    <StackPanel>
    <ListBox ItemsSource="{Binding Pictures}">
        <ListBox.ItemTemplate>
           <DataTemplate>
              <Image Source="{Source}" />
           </DataTemplate>
        </ListBox.ItemTeplate>
    </ListBox> 
    <Button Tap="LoadImages_Tap" Content="Load Images" />
    </StackPanel> 
 
-
     //Picture.cs
        public class Picture
        { 
            private BitmapImage _source = new BitmapImage()
            {
                CreateOptions = BitmapCreateOptions.BackgroundCreation | BitmapCreateOptions.IgnoreImageCache | BitmapCreateOptions.DelayCreation
            };
    
            public Picture(string url) {
                _source.UriSource = new Uri(url, UriKind.Absolute);
            }
            public BitmapImage Source
            {
                get
                {
                    return _source;
                } 
            } 
     
        }
    }
 
    //MainPage.xaml.cs
    private ObservableCollection<Picture> _pictures = new ObservableCollection<Picture>();
    public ObservableCollection<Picture> Pictures {
      get {
       return _pictures;
      }
    }
    public MainPage() {
      //...
      DataContext = this;
    }
      
    protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
    {
            if (e.NavigationMode == NavigationMode.Back)
            {
                PreventCaching();
            }
            base.OnNavigatedFrom(e);
    }  
    private void PreventCaching() {
       foreach(var picture in _pictures) {
         picture.Source.UriSource = null;
       }
    }
    private void LoadPictures_Tap(object sender, EventArgs e) { 
         PreventCaching();
        _pictures.Clear();
        foreach(var url in SomeMethodThatReturnsUrlsForImages()) {  
          _pictures.Add(new Picture(url));
        }
    }
