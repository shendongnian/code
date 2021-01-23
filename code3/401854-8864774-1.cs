    #region Start the Splash Screen
    /// <summary>
    /// Starts the splash.
    /// </summary>
    /// <remarks>
    /// 	<para>AUTHOR: Dirk Strauss</para>
    /// 	<para>DATE WRITTEN: 29/01/2011</para>
    /// 	<para>LAST DATE:  29/01/2011</para>
    /// </remarks>
    static public void StartSplash()
    {
        // Instance a splash form given the image names
        splash = new frmSplash(kSplashUpdateInterval_ms);
        // Run the form
        Application.Run(splash);
    } 
    #endregion
