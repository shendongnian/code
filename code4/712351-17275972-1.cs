    partial class GalleryDictionary
    {
          public GalleryDictionaryViewModel GDViewModel;
          public GalleryDictionary()
          {
              GDViewMOdel = new GDViewModel();
              GDViewModel.DriveOnRight = "";
              this.DataContext = GDViewModel;
          }
    }
