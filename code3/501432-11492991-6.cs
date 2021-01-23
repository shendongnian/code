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
    
        protected override ListViewDataItem CreateDataItem(int
                               dataItemIndex, int displayIndex) {
          // Fire a NEW event: ItemCreating
          if (ItemCreating != null)
            ItemCreating(this, new ListViewItemCreatingEventArgs
                                 (dataItemIndex, displayIndex));
    
          // Call the base method
          return base.CreateDataItem(_dataItemIndex, displayIndex);
        }
      }
    }
 
