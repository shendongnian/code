      [KnownType( typeof( UserInfoEnrolledResult ) )]
      [KnownType( typeof( UserInfoNotEnrolledResult ) )]
      [DataContract]
      public abstract class UserInfoResult
      {
      }
      [DataContract]
      public class UserInfoEnrolledResult : UserInfoResult
      {
        [DataMember]
        public string UserOptions { get; set; }
    
        [DataMember]
        public string[] Items { get; set; }
      }
      [DataContract]
      class UserInfoNotEnrolledResult : UserInfoResult
      {
        [DataMember]
        public bool UserIsValid { get; set; }
      }
