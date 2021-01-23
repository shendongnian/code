    namespace NamespaceShared
    {
        using System.Runtime.Serialization;
    
        public class SharedType
        {
            [DataMember(IsRequired = true)]
            public int ValueOne { get; set; }
    
            [DataMember(IsRequired = true)]
            public int ValueTwo { get; set; }
        }
    
        [DataContract(Namespace = "http://namespace.one")]
        public class SharedTypeOne : SharedType
        {
        }
    
        [DataContract(Namespace = "http://namespace.two")]
        public class SharedTypeTwo : SharedType
        {
        }
    }
    
    namespace NamespaceOne
    {
        using System.Runtime.Serialization;
        using NamespaceShared;
    
        [DataContract(Namespace = "http://namespace.one")]
        public sealed class DataContractOne
        {
            [DataMember(IsRequired = true)]
            private SharedTypeOne SharedValue { get; set; }
        }
    }
    
    namespace NamespaceTwo
    {
        using System.Runtime.Serialization;
        using NamespaceShared;
    
        [DataContract(Namespace = "http://namespace.two")]
        public sealed class DataContractTwo
        {
            [DataMember(IsRequired = true)]
            private SharedTypeTwo SharedValue { get; set; }
        }
    }
