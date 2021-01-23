    class Token {
        string TokenName;
        string TokenIdentifier;
        PropertyInfo TokenReplacement;
    }
    private readonly List<Token> _tokens = new List<Token>
    {
      new Token
      {
        TokenName = "Lan ID",
        TokenIdentifier = "<!--LANID-->",
        TokenReplacement = typeof(BasicUser).GetProperty("LanID")
      },
      new Token
      {
        TokenName = "First Name",
        TokenIdentifier = "<!--FirstName-->",
        TokenReplacement = typeof(BasicUser).GetProperty("FirstName")
      }
    };
    
    public string ReplaceTokens(string Input, string LanID)
    {
      string OutputString = "";
      BasicUser User = GetParticipantInformation(Input);
      foreach (var token in _tokens)
      {
        OutputString = OutputString.Replace(token.TokenName, token.TokenReplacement.GetValue(User, null).ToString());
      }
      return OutputString;
    }
