    public class MainViewModel : INotifyPropertyChanged
    {
      //Use a readonly observable collection. If you need to reset it use the .Clear() method
      private readonly ObservableCollection<MagazineViewModel> magazines = new ObservableCollection<MagazineViewModel>();
      private MagazineViewModel selectedItem;
      //Keep the item being edited separate to the selected item
      private MagazineViewModel itemToEdit;
      public ObservableCollection<MagazineViewModel> Magazines { get { return magazines; } }
      public MagazineViewModel SelectedItem
      {
        get { return selectedItem; }
        set
        {
          if (selectedItem != value)
          {
            selectedItem = value;
            RaisePropertyChanged("SelectedItem");
            //When the selected item changes. Copy it to the ItemToEdit
            //This keeps the the copy you are editing separate meaning that invalid data isn't committed back to your original view model
            //You will have to copy the changes back to your original view model at some stage)
            ItemToEdit = Copy(SelectedItem);
          }
        }
      }
      public MagazineViewModel ItemToEdit
      {
        get { return itemToEdit; }
        set
        {
          if (itemToEdit != value)
          {
            itemToEdit = value;
            RaisePropertyChanged("ItemToEdit");
          }
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      public MainViewModel()
      {
        //Ctor...
      }
      //Create a copy of a MagazineViewModel
      private MagazineViewModel Copy(MagazineViewModel ToCopy)
      {
        var vm = new MagazineViewModel();
        vm.Navn = ToCopy.Navn;
        vm.Pris = ToCopy.Pris;
        return vm;
      }
      private void RaisePropertyChanged(string PropertyName)
      {
        //...
      }
    }
