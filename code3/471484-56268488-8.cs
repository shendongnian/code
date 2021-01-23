    public IWebDriver Driver { get; private set; }
    // ...
    const int GlobalPageLoadTimeOutSecs = 10;
    static readonly TimeSpan DefaultPageLoadTimeout =
        new TimeSpan((long) (10_000_000 * GlobalPageLoadTimeOutSecs));
    Driver = new FirefoxDriver();
