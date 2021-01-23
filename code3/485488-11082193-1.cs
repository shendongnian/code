    public class GetCustomer
    {
      public Guid InteractionId { get; set; }
      public Dictionary<String, Object> CustomerInfo { get; set; }
      public GetCustomer(Guid interactionId, string customerInfo)
      {
        InteractionId = interactionId;
        CustomerInfo = new JavaScriptSerializer().Deserialize<Dictionary<String,Object>>(customerInfo);
      }
    }
    ...
    string result = new JavaScriptSerializer.Serialize(new GetCustomer(interactionId, customerInfo));
