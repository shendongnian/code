            /// Log a user out of Facebook.
            /// </summary>
    
       public void Logout()
        {
            try
            {
                FacebookSessionCacheProvider.Current.DeleteSessionData();
            }
            finally
            {
                this.CurrentSession = null;
            }
        }
