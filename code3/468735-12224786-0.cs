    public class LoginResult
    {
        public string Code { get; set; }
        public string SubCode { get; set; }
        public string SecToken { get; set; }
    }
    public static IDictionary<Predicate<LoginResult>, Func<LoginResult, string>> rules =
        new Dictionary<Predicate<LoginResult>, Func<LoginResult, string>>
            {
                { lr => lr.Code == "0" && lr.SubCode != "0", result => "Login successful, days left till expiration: " + result.SubCode },
                { lr => lr.Code == "0", _ => "Login successful" },
                { lr => lr.Code == "21", _ => ThrowInvalidOperation("Login failed. (Userid/password wrong).") },
            };
    static string ThrowInvalidOperation(string message)
    {
        throw new InvalidOperationException(message);
    }
    static string Match(LoginResult result)
    {
        foreach (var rule in rules)
        {
            if (rule.Key(result))
            {
                return rule.Value(result);
            }
        }
        throw new ArgumentException("Matching rule not found", "result");
    }
