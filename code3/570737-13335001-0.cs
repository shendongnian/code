    [ProtoContract]
    public class SomethingContainingAnAuthenticationMethod
    {
      [ProtoMember(1)] 
      private int? AuthenticationMethodDataTransferField {
          get { return AuthenticationMethod == null ? (int?)null
                                   : AuthenticationMethod.Value; }
          set { AuthenticationMethod = value == null ? null
                                   : AuthenticationMethod.FromInt(value.Value); }
      }
      public AuthenticationMethod AuthenticationMethod { get; set; }
    }
