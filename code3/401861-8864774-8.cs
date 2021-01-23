    #region Close the Splash Screen
    /// <summary>
    /// Closes the splash.
    /// </summary>
    /// <remarks>
    /// 	<para>AUTHOR: Dirk Strauss</para>
    /// 	<para>DATE WRITTEN: 29/01/2011</para>
    /// 	<para>LAST DATE:  29/01/2011</para>
    /// </remarks>
    private void CloseSplash()
    {
        if (splash == null)
            return;
        // Shut down the splash screen
        splash.Invoke(new EventHandler(splash.KillMe));
        splash.Dispose();
        splash = null;
    } 
    #endregion
