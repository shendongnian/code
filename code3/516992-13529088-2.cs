    [XmlInclude(typeof(BankPayment))]
    [Serializable]
    public Payment { }    
        
    [Serializable]
    public class BankPayment : Payment {} 
    
    [Serializable]
    public class Payments : List<Payment>{}
    XmlSerializer serializer = new XmlSerializer(typeof(Payments), new Type[]{typeof(Payment)});
