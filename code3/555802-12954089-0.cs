     public Visibility SendToServerVisiblity
        {
            get
            {
                if (IsOnlineMode)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }
