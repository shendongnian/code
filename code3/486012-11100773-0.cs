    #region "Timer Elapsed Event"
        /// <summary>
        /// Handles the Elapsed event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        void DipRedipServiceTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
                       
            try
            {                
                IDipRedipController controller = new DipRedipController();
                try
                {
                    DipRedipConfiguration config = controller.GetDipRedipConfiguration();                    
                    if (config != null)
                    {
                        //set timer interval after reading from config file.                        
                        controller.dipRedipConfiguration = config;
                        LoggingHelper.LogMessage(String.Format("Dip Service timer initialized at {0}", DateTime.UtcNow), Source.EDiscDIPREDIPService, LogCategory.Exception);
                        //Process Dip
                        bool dipSuccess = controller.ProcessDIP();
                        //Process Re-Dip
                        bool redipSuccess = controller.ProcessREDIP();
                        // In case configuration has been retrieved, set timer defined.
                        DipRedipServiceTimer.Interval = config.FileGenerationInterval * 60000;
                        //Enable timers for next cycle
                        LoggingHelper.LogMessage(String.Format("Dip Service timer completed at {0}", DateTime.UtcNow), Source.EDiscDIPREDIPService, LogCategory.Exception);
                    }
                    // In case configuration is null, get the default timer defined in App.Config file.
                    else
                    {
                        int interval = 0;
                        int.TryParse(ConfigurationManager.AppSettings.Get("DefaultTimerValue"), out interval);
                        DipRedipServiceTimer.Interval = interval * 60000;
                        LoggingHelper.LogWarning("Configuration for Dip/Redip could not be fetched from database.", Source.EDiscDIPREDIPService, LogCategory.Exception);
                    }                                        
                    DipRedipServiceTimer.Start();
                }
                catch (Exception ex)
                {
                    LoggingHelper.LogException("Exception Occured in DipRedipServiceTimer_Elapsed method of Dip/Redip Window Service", ex, Source.EDiscDIPREDIPService);                    
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogException("Exception Occured in the DipRedip Service Host Window Service", ex, Source.EDiscDIPREDIPService);               
            }
         }
        #endregion 
