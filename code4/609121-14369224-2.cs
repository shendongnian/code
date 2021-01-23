    using System.Reflection;
    using System.Runtime.Serialization;      // You will have to add a reference
    using System.Runtime.Serialization.Json; // to System.Runtime.Serialization.dll
    
    [DataContract]
    public class Address
    { 
      [DataMember(Name = "address")]
      public string Address { get; set; }
      
      [DataMember(Name = "version")]
      public int Version { get; set; }
    }
    [DataContract]
    public class AddressList
    { 
      [DataMember(Name = "public")]
      public IEnumerable<Address> Public { get; set; }
      [DataMember(Name = "private")]
      public IEnumerable<Address> Private { get; set; }
      [DataMember(Name = "User-Defined-Network-Name")]
      public IEnumerable<Address> UserDefined { get; set; }
    }
