    public class SomeModelExtensions {
          public AppDetailViewModel CreateInstance(this SomeModel model) {
               var viewModel = new AppDetailViewModel();
               // here you create viewmodel object from model with logic
               return viewModel;
          }
    }
