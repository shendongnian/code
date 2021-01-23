    class Token {
        Func<BasicUser, object> TokenReplacement;
        // ...
    }
    // ...
      new Token
      {
        TokenName = "Lan ID",
        TokenIdentifier = "<!--LANID-->",
        TokenReplacement = user => user.LanID,
      },
      new Token
      {
        TokenName = "First Name",
        TokenIdentifier = "<!--FirstName-->",
        TokenReplacement = user => user.FirstName,
      },
    // ...
    OutputString = OutputString.Replace(token.TokenName,
        token.TokenReplacement(User).ToString());
