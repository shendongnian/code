    using System.Threading;
    public void SomeWhereInYourApp() {
        bool wasIAuthenticated = Thread.CurrentPrincipal.Identity.IsAuthenticated;
        string whatIsMyUsername = Thread.CurrentPrincipal.Identity.Name;
        // do something with that information
    }
