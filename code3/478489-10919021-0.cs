        // Field Definitions
        /// <summary>
        /// Constants that relate to the WndProc messages we wish to intercept and evaluate.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Standard practice to use this naming style for Win32 API Constants.")]
        private const int WM_SYSCOMMAND = 0x0112, SC_MONITORPOWER = 0xF170;
        /// <summary>
        /// Gets or sets whether we are suspended. Should coincide with whether the display is turned on or not.
        /// </summary>
        private bool isSuspended = false;
        // New overridden method
        /// <summary>
        /// Intercepts WndProc messages. We are looking for the screen suspend activity. From it, we will return that we are able to suspend and we ourselves will suspend.
        /// </summary>
        /// <param name="m">Message to be checked.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                // The 0x000F bits are used to indicate the specific state and must be ignored to see if this is a monitor power event.
                if ((m.WParam.ToInt32() & 0xFFF0) == SC_MONITORPOWER)
                {
                    switch (m.WParam.ToInt32() & 0x000F)
                    {
                        case -1:
                            // Display powering on - resume operation
    #if DEBUG
                            System.Diagnostics.Debug.WriteLine("Display powered on.");
    #endif
                            this.isSuspended = false;
                            break;
                        case 0:
                        case 1:
                        case 2:
                            // Display being powered off - suspend operation
    #if DEBUG
                            System.Diagnostics.Debug.WriteLine("Display suspended");
    #endif
                            this.isSuspended = true;
                            break;
                        default:
    #if DEBUG
                            System.Diagnostics.Debug.WriteLine(string.Format("Unknown power state: {0}", (m.WParam.ToInt32() & 0x000F).ToString("0")));
    #endif
                            // Assuming that unknown values mean to power off. This is a WAG.
                            this.isSuspended = true;
                            break;
                    }
                }
            }
            base.WndProc(ref m);
        }
        // Change to my refreshing timer.
        /// <summary>
        /// Called when the refresh timer ticks. This invalidates the form, forcing it to be redrawn, which creates a framerate for us.
        /// </summary>
        /// <param name="sender">Who called this method.</param>
        /// <param name="e">Event Arguments.</param>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (this.isSuspended)
            {
                // Program is in suspended mode, so don't do anything this update.
                return;
            }
            // Program is not suspended, so invalidate the client area so it can be painted again.
            this.Invalidate();
        }
