    public class OrderModel {
      private string _referenceNumber;
      public string ReferenceNumber {
        get { return _referenceNumber; }
        set { _referenceNumber = value; }
      }
      ...
      class OrderItem {
        private int _itemEntityId;
        public int ItemEntityId {
          get { return _itemEntityId; }
          set { _itemEntityId; }
        }
        ....
      }
    }
