    [ExcludeFromCodeCoverage]
    private static string GetAuthorizationToken(HttpActionContext actionContext)
    {
      if (YourClass.AnonymousMethodDelegate == null)
      {
        // ISSUE: method pointer
        YourClass.AnonymousMethodDelegate = new Func<string, bool>((object) null, __methodptr(CompilerGeneratedMethod));
      }
      Func<string, bool> predicate = YourClass.AnonymousMethodDelegate;
      return Enumerable.FirstOrDefault<string>((IEnumerable<string>) actionContext.Request.Headers, predicate);
    }
