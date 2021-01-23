        public override void Write(byte[] buffer, int offset, int count)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                _OutBox.Text += Encoding.UTF8.GetString(buffer, offset, count);
            });
        }
