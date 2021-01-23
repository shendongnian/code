    // C#
    // Put the using statements at the beginning of the code module
    using System.Threading;
    using System.Globalization;
    // Put the following code before InitializeComponent()
    // Sets the culture to English (US)
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    // Sets the UI culture to English (US)
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
