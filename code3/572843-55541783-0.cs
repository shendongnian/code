    //Todo: use abstract factory pattern to detect Windows 8 and in that case use a toastnotification instead
            private void DisplayNotificationBalloon(string header, string message)
            {
                NotifyIcon notifyIcon = new NotifyIcon
                {
                    Visible = true,
                    Icon = SystemIcons.Application
                };
                if (header != null)
                {
                    notifyIcon.BalloonTipTitle = header;
                }
                if (message != null)
                {
                    notifyIcon.BalloonTipText = message;
                }
                notifyIcon.BalloonTipClosed += (sender, args) => dispose(notifyIcon);
                notifyIcon.BalloonTipClicked += (sender, args) => dispose(notifyIcon);
                notifyIcon.ShowBalloonTip(0);
            }
    
            private void dispose(NotifyIcon notifyIcon)
            {
                notifyIcon.Dispose();
            }
