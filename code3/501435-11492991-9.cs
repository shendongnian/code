    namespace Samples.Controls
    {
      public class ListViewItemCreatingEventArgs : EventArgs
      {
        private int _dataItemIndex;
        private int _displayIndex;
    
        public ListViewItemCreatingEventArgs(int dataItemIndex,
                                             int displayIndex) {
          _dataItemIndex = dataItemIndex;
          _displayIndex = displayIndex;
        }
    
        public int DisplayIndex {
          get { return _displayIndex; }
          set { _displayIndex = value; }
        }
    
        public int DataItemIndex {
          get { return _dataItemIndex; }
          set { _dataItemIndex = value; }
        }
      }
    
      public class ListView : System.Web.UI.WebControls.ListView
      {
        public event EventHandler<ListViewItemCreatingEventArgs>
         ItemCreating;
    
        private int _displayIndex;
        private bool _shouldInstantiate = false;
    
        protected override void InstantiateItemTemplate(Control container,
         int displayIndex) {
          if (_shouldInstantiate) {
            base.InstantiateItemTemplate(container, displayIndex);
            _shouldInstantiate = false;
          }
        }
    
        protected override ListViewDataItem CreateDataItem(int
         dataItemIndex, int displayIndex) {
          // Fire a NEW event: ItemCreating
          if (ItemCreating != null)
            ItemCreating(this, new
              ListViewItemCreatingEventArgs(dataItemIndex,
              displayIndex));
    
          // Cache for later
          _displayIndex = displayIndex;
    
          // Call the base method
          return base.CreateDataItem(_dataItemIndex, displayIndex);
        }
    
        protected override void OnItemCreated(ListViewItemEventArgs e) {
          base.OnItemCreated(e);
    
          // You can proceed with template instantiation now
          _shouldInstantiate = true;
          InstantiateItemTemplate(e.Item, _displayIndex);
        }
      }
    }
 
