    [ProtoContract]
    public class SomethingContainingAnAuthenticationMethod
    {
        [ProtoMember(1)] 
        public AuthenticationMethod AuthenticationMethod { get; set; }
    }
