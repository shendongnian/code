     private void StartTimerForDeleteMessage(UC_ChatReceiveMessageControl ucChatReceiveMessageControl)
        {
            try
            {
                System.Timers.Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed += (sender, e) => MyElapsedMethod(sender, e, ucChatReceiveMessageControl);
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Helper.WriteToLogFile("SetMessageBodyContentAfterAcknoledged ex::" + ex.Message, LoggingLevel.Errors);
            }
        }
        static void MyElapsedMethod(object sender, ElapsedEventArgs e, UC_ChatReceiveMessageControl ucChatReceiveMessageControl)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Helper.WriteToLogFile("SetMessageBodyContentAfterAcknoledged ex::" + ex.Message, LoggingLevel.Errors);
            }
        }
