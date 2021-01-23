        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ((IChannel)service).Close();
        }
