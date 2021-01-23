        private Boolean terminating;
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!terminating)
            {
                terminating = true;
                Close();
            }
            base.OnClosing(e);
        }
