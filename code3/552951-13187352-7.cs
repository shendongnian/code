    [ExcludeFromCodeCoverage]
    private static string GetAuthorizationToken(HttpActionContext actionContext)
    {
      AnonymousMethodDelegate = CompilerGeneratedMethod;
      Func<string, bool> predicate = AnonymousMethodDelegate;
      return Enumerable.FirstOrDefault<string>((IEnumerable<string>) actionContext, predicate);
    }
