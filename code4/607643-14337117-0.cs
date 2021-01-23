    public class Order : INotifyPropertyChanged
    {
       private readonly ObservableCollection<OrderDetail> m_details = new ...
       
       public ObservableCollection<OrderDetail> Details { get { return m_details; } }
       public decimal Total {
         get {
           decimal total = 0.0;
           foreach(var detail in m_details) total += detail.SubTotal;
           return total;
         }
       }
    }
    public class OrderDetail : INotifyPropertyChanged
    {
       private readonly Order m_order;
       public OrderDetail(Order order) {
         m_order = order;
       }       
       private string m_name;
       public string Name
       {
         get { return m_name; }
         set {
           if(m_name != value) {
             m_name = value;
             RaisePropertyChanged("Name");
           }
         }
       }
       private int m_amount;
       public int Amount {
         get { return m_amount; }
         set {
           if(m_amount != value) {
             m_amount = value;
             RaisePropertyChanged("Amount");
             RaisePropertyChanged("SubTotal");
             m_order.RaisePropertyChanged("Total");
           }
         }
       }
       private decimal m_unitPrice;
       public decimal UnitPrice {
         get { return m_amount; }
         set {
           if(m_unitPrice!= value) {
             m_unitPrice = value;
             RaisePropertyChanged("UnitPrice");
             RaisePropertyChanged("SubTotal");
             m_order.RaisePropertyChanged("Total");
           }
         }
       }
       public decimal SubTotal { get { return Amount * UnitPrice; } }
    }
