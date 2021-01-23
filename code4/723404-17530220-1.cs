    //your Employee form
    public class Employee : Form {
        public Employee(){
           InitializeComponent();
           searchForm.ItemSelected += ItemSelected;
        }
        //Search form
        private SearchForm searchForm = new SearchForm();
        //your ItemSelected handler
        private void ItemSelected(object sender, ItemSelectedEventArgs e){
           txtName.Text = e.SelectedItem.ToString();
        }
    }
    //your Search form
    public class SearchForm : Form {
      public SearchForm(){
         InitializeComponent();
      }
      //handler for your combobox SelectedValueChanged event.
      private void cbFind_SelectedValueChanged(object sender, EventArgs e)
      {
        if (cbFind.SelectedItem != null)
        {
           if(ItemSelected != null) ItemSelected(this, new ItemSelectedEventArgs(cbFind.SelectedItem);
        }
      }
      public delegate void ItemSelectedEventHandler(object sender, ItemSelectedEventArgs e);
      //your own event
      public event ItemSelectedEventHandler ItemSelected;
    }
    public class ItemSelectedEventArgs : EventArgs {
      public object SelectedItem {get;set;}
      public ItemSelectedEventArgs(object selectedItem){
         SelectedItem = selectedItem;
      }
    }
