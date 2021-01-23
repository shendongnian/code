    // used by clients needing to authenticate
    public interfac ISecurity {
      AuthenticationResponse Login(Credentials credentials);
    }
    // the response from calling ISecurity.Login
    public class AuthenticationResponse {
      
      internal AuthenticationResponse(bool succeeded, AuthenticationToken token, string accountId) {
        Succeeded = succeeded;
        Token = token;
      }
      // if true then there will be a valid token, if false token is undefined
      public bool Succeeded { get; private set; }
      // token representing the authenticated user.
      // document the fact that if Succeeded is false, then this value is undefined
      public AuthenticationToken Token { get; private set; }
    }
    // token representing the authenticated user. simply contains the user name/id
    // for convenience, and a base64 encoded string that represents encrypted bytes, can
    // contain any information you want.
    public class AuthenticationToken {
      internal AuthenticationToken(string base64EncodedEncryptedString, string accountId) {
        Contents = base64EncodedEncryptedString;
        AccountId = accountId;
      }
      // secure, and user can serialize it
      public string Contents { get; private set; }
      // used to identify the user for systems that aren't related to security
      // (e.g. customers this user has)
      public string AccountId { get; private set; }
    }
    // simplified, but I hope you get the idea. It is what is used to authenticate
    // the user for actions (i.e. read, write, modify, etc.)
    public interface IAuthorization {
      bool HasPermission(AuthenticationToken token, string permission); 
    }
 
