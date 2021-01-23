        private DateTime _lastClickTime;
        private WeakReference _lastSender;
        private void Row_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var now = DateTime.Now;
            if ((now - _lastClickTime).TotalMilliseconds < 200 && _lastSender != null && _lastSender.IsAlive && _lastSender.Target == sender)
            {
                if (Command != null)
                {
                    Command.Execute(CommandParameter);
                }
            }
            _lastClickTime = now;
            _lastSender = new WeakReference(sender);
        }
