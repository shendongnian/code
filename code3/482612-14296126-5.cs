    namespace MyApplication.Presentation.ViewModels {
        public sealed class MyPageViewModel : DependencyObject {
            private readonly ObservableCollection<ItemViewModel> items;
            private readonly RoutedCommand load;
            private readonly RoutedCommand saveCommand;
            private readonly RoutedCommand updateSelectedCommand;
            public MyPageViewModel() {
               items = new ObservableCollection<ItemViewModel>();
               load = new RoutedCommand<MultiselectList>(
                    m => {
                        IEnumerable<Item> store = loadItems();
                        IEnumerable<Item> selected = loadSelectedItems();
                        populateSelectionList(m, store, selected);
                    });
               updateSelectedCommand = new RoutedCommand<IList>(setSelected);
               // use the savecommand on a button or a BindableApplicationBarButton
               // or execute the command when you're navigating away from the page
               saveCommand = new RoutedCommand<object>(o => storeItems(items));
            }
            public ICommand LoadCommand {
                get { return load; }
            }
            public ICommand UpdateSelectedCommand {
                get { return updateSelectedCommand; }
            }
            public ICommand SaveCommand {
                get { return saveCommand; }
            }
            private void populateSelectionList(MultiselectList list, IEnumerable<Item> storage, IEnumerable<Item> selected) {
                foreach (Item item in selected) {
                    ItemViewModel viewModel = new ItemViewModel(item);
                    list.SelectedItems.Add(viewModel);
                    items.Add(viewModel);
                }
                foreach (string item in storage) {
                    bool found = false;
                    foreach (Item select in selected) {
                        if (select == item) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        ItemViewModel viewModel = new ItemViewModel(item);
                        items.Add(viewModel);
                    }
                }
            }
            private void setSelected(IList list) {
                // triggered when user selects or deselects an item in GUI
                foreach (ItemViewModel viewModel in items) {
                    viewModel.IsSelected = false;
                }
                foreach (object item in list) {
                    ItemViewModel item = (ItemViewModel)item;
                    foreach (ItemViewModel tvm in items) {
                        if (tvm == item) {
                            tvm.IsSelected = true;
                            break;
                        }
                    }
                }
            }
            private static void storeItems(IEnumerable<ItemViewModel> enumerable) {
                // get all selected items
                List<ItemViewModel> selected = new List<ItemViewModel>();
                foreach (ItemViewModel viewModel in enumerable) {
                    if (viewModel.IsSelected) {
                        selected.Add(viewModel);
                    }
                }
                // save selected items in storage
                saveSelectedItems(selected);
                // save enumerable (i.e. all items) in storage
                saveItems(enumerable);
            }
            private static void saveItems(IEnumerable<ItemViewModel> items) {
                // todo: save enumerable to storage
                foreach (ItemViewModel item in items) {
                    //saveItem(item.Model);
                }
            }
            private static IEnumerable<Item> loadItems() {
                // todo: load from storage
            }
            private static void saveSelectedItems(IEnumerable<Item> items) {
       	        // todo: save selected to storage
            }
            private static IEnumerable<Item> loadSelectedItems() {
                // todo: load from storage
            }
        }
    }
