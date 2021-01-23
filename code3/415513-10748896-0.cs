            if (!this.apnsStream.IsMutuallyAuthenticated)
            {
                if (this.Error != null)
                {
                    this.Error(this, new NotificationException(4, "Ssl Stream Failed to Authenticate"));
                }
            }
            if (!this.apnsStream.CanWrite)
            {
                if (this.Error != null)
                {
                    this.Error(this, new NotificationException(5, "Ssl Stream is not Writable"));
                }
            }
