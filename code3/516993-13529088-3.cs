    [XmlInclude(typeof(BankPayment))]
    [Serializable]
    public abstract class Payment { }    
        
    [Serializable]
    public class BankPayment : Payment {} 
    
    [Serializable]
    public class Payments : List<Payment>{}
    XmlSerializer serializer = new XmlSerializer(typeof(Payments), new Type[]{typeof(Payment)});
