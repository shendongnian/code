    public class MyPrincipal : IPrincipal
        {
            private readonly IPrincipal principal_;
    
            public MyPrincipal(ILifetimeScope scope)
            {
                if (scope.Tag == null || scope.Tag != MatchingScopeLifetimeTags.RequestLifetimeScopeTag)
                {
                    throw new Exception("Invalid scope");
                }
    
                principal_ = scope.Resolve<HttpRequestMessage>().GetRequestContext().Principal;
            }
    }
