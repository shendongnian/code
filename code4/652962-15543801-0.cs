        OperationContext.Current.Channel.Closed += channelClosed;
        void Channel_Closed(object sender, EventArgs e)
        {
            var success = false;
            try
            {           
               proxy.Close();
               success = true;
            }
            finally
            {
              if (!success) proxy.Abort();           
            }
        }
