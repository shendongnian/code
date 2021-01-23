    using System.ServiceModel;
    
    [ServiceContract]
    public interface IUIInterop {
        [OperationContract]
        void SetControlValue (UIControl c);
    }
    [DataContract]
    public class UIControl {        
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Value { get; set; }
    }
