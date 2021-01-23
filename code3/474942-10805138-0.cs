    public partial class SHIPMENT_LINE : ISetConnection
    {
       private ConnectionSetter connector = new ConnectionSetter();
    
       public void SetConnection(BHLibrary.Configuration.ConnectionOption Environment)
       {
          this.connector.SetConnection(Environment);
       }
    }
    
    public class ConnectionSetter : ISetConnection
    {
        public void SetConnection(BHLibrary.Configuration.ConnectionOption Environment)
       {
          // Implementation
       }
    }
