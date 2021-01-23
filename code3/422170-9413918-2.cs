    public interface IFreight
    {
        IFreightContent Content{get;}
        Type ContentType { get { return Content.GetType() }}
        PostalAddress DeliveryAddress {get;}
    }
    
  
    public interface IFreightContent
    {
    }
    
    // we don't just deliver the pizza, do we? ;)
    public class PizzaBox : IFreightContent
    {
    }
